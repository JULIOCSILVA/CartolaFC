﻿using Cartola.Domain.Entidades;
using Cartola.Infra.Interface;
using Cartola.Web.Helper;
using Cartola.Web.ViewModel.LigaDetalhe;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cartola.Web.Controllers
{
    public class LigaDetalheController : Controller
    {
        private readonly IClientApiCartola _clientApiCartola;

        public LigaDetalheController(IClientApiCartola clientApiCartola)
        {
            _clientApiCartola = clientApiCartola;
        }

        public async Task<IActionResult> Index(string slug)
        {
            slug = slug?.Replace(" ", "-").ToLower().Trim();
            var model = new LigaDetalheViewModel();

            try
            {
                var response = await _clientApiCartola.BuscarInformacaoLiga(string.IsNullOrEmpty(slug) ? "nacional" : slug);
                if (!response.IsSuccessStatusCode)
                    return StatusCode(500, response.Error.Content);

                var ligaRetorno = response.Content;
                var liga = ligaRetorno.liga;
                var times = ligaRetorno.times;

                var responseMercado = await _clientApiCartola.VerificarRodada();
                if (!responseMercado.IsSuccessStatusCode)
                    throw new Exception("Erro ao buscar informação do mercado");

                model.BlMercadoAberto = responseMercado.Content.status_mercado == 2;
                model.Rodada = responseMercado.Content.rodada_atual;

                if (liga != null)
                {
                    model.nome = liga.nome;
                    model.descricao = liga.descricao;
                    model.url_flamula_svg = liga.url_flamula_svg;

                    if (model.BlMercadoAberto)
                    {
                        var responseAtletaPontuado = await _clientApiCartola.RetornaAtletasPontuados();
                        if (!responseAtletaPontuado.IsSuccessStatusCode)
                            throw new Exception("Erro ao buscar informação de jogador pontuado");

                        model.AtletasPontuacao = responseAtletaPontuado.Content;
                    }
                }

                foreach (var time in times)
                    await AdicionaClube(model, liga, time);

                AjustaPosicaoTabela(model);
            }
            catch (Exception)
            {
                throw;
            }

            return View(model);
        }

        [HttpPost]
        public PartialViewResult ClubeDetalhe([FromBody] ClubeViewModel clube)
        {
            string nome = string.Empty;
            var atualizacaoAtletas = new List<Atletas>();
            foreach (var atleta in clube.Atletas)
            {
                var atletaPontuado = clube.AtletasPontuacao.Where(a => a.atleta_id == atleta.atleta_id).FirstOrDefault();
                //Adiciona na lista caso o Jogador já tenha entrado em campo
                if (atletaPontuado != null)
                {
                    atletaPontuado.Capitao = atleta.atleta_id == clube.capitao_id;
                    atletaPontuado.pontuacao *= clube.sem_capitao ? 1 : atletaPontuado.Capitao ? 2 : 1;
                    PreencheScouts(atletaPontuado);
                    atualizacaoAtletas.Add(atletaPontuado);
                }
                else //Adiciona na lista caso o jogador não tenha entrado em campo
                {
                    atleta.Capitao = atleta.atleta_id == clube.capitao_id;
                    atleta.pontuacao *= clube.sem_capitao ? 1 : atleta.Capitao ? 2 : 1;
                    PreencheScouts(atleta);
                    atualizacaoAtletas.Add(atleta);
                }
            }

            clube.index = clube.index;
            clube.Atletas = atualizacaoAtletas.OrderBy(q => q.posicao_id).ToList();

            return PartialView("ClubeDetalhe", clube);
        }

        private static void PreencheScouts(Atletas atleta)
        {
            Dictionary<string, string> scout = atleta.scout;
            string listScout = string.Empty;
            if (scout != null)
            {
                foreach (var itemScout in scout)
                {
                    listScout += itemScout.Key + ": " + TipoPontuacao.RetornaPontuacao(itemScout.Key, Convert.ToInt32(itemScout.Value)).ToString("N2") + "\n";
                }

                atleta.Scouts = listScout;
            }
        }

        private static void AjustaPosicaoTabela(LigaDetalheViewModel model)
        {
            int posicao = 1;
            foreach (var item in model.Clubes.OrderByDescending(i => i.UltimaPontuacaoTotal).ThenBy(i => i.NomeTime.Trim()))
            {
                item.PosicaoCampeonato = posicao;
                posicao++;
            }

            posicao = 1;

            foreach (var item in model.Clubes.OrderByDescending(i => i.Pontos.campeonato).ThenBy(i => i.NomeTime.Trim()))
            {
                item.PosicaoCampeonatoParcial = posicao;
                posicao++;
            }

            posicao = 1;

            if (!model.BlMercadoAberto)
            {
                foreach (var item in model.Clubes.OrderByDescending(i => i.Pontos.rodada).ThenBy(i => i.NomeTime.Trim()))
                {
                    item.PosicaoRodada = posicao;
                    posicao++;
                }
            }
            else
            {
                foreach (var item in model.Clubes.OrderByDescending(i => i.Pontos.campeonato).ThenBy(i => i.NomeTime.Trim()))
                {
                    item.PosicaoRodada = posicao;
                    posicao++;
                }
            }


            int index = 1;
            foreach (var item in model.Clubes.OrderByDescending(a => model.BlMercadoAberto ? a.Pontos.campeonato : a.Pontos.rodada))
            {
                item.index = index;
                item.JsonData = JsonConvert.SerializeObject(item);
                index++;
            }
        }

        private async Task AdicionaClube(LigaDetalheViewModel model, Liga liga, Time time)
        {
            Clube clube = new Clube
            {
                Slug = time.slug,
                NomeTime = time.nome,
                NomeCartoleiro = time.nome_cartola,
                Url = time.url_escudo_png,
                Pontos = time.pontos,
                sem_capitao = liga.sem_capitao,
                time_id = time.time_id,
                capitao_id = time.capitao_id,
                AtletasPontuacao = model.AtletasPontuacao
            };

            var responseAtletasClube = await _clientApiCartola.RetornaTimePorIdRodada(clube.time_id, 0);
            if (!responseAtletasClube.IsSuccessStatusCode)
                throw new Exception("Erro ao buscar informação do mercado");

            clube.Atletas = responseAtletasClube.Content.atletas;
            clube.capitao_id = responseAtletasClube.Content.capitao_id;

            if (clube.AtletasPontuacao != null)
                clube.Pontos.rodada = clube.AtletasPontuacao.Where(x => clube.Atletas.Any(y => y.atleta_id == x.atleta_id)).Sum(x => (x.atleta_id == clube.capitao_id ? x.pontuacao * 2 : x.pontuacao));

            if (!clube.BlMercadoAberto)
                clube.Pontos.campeonato = clube.Pontos.campeonato != null ? clube.Pontos.campeonato : clube.Pontos.rodada;
            else
                clube.Pontos.campeonato = clube.Pontos.campeonato.HasValue ? clube.Pontos.campeonato + clube.Pontos.rodada : clube.Pontos.rodada;

            clube.Patrimonio = Convert.ToDecimal(time.patrimonio);
            clube.UltimaPontuacao = time.pontos.rodada.HasValue ? time.pontos.rodada.Value : 0;
            clube.UltimaPontuacaoTotal = Convert.ToDecimal(clube.Pontos.campeonato) - clube.UltimaPontuacao;

            model.Clubes.Add(clube);
        }
    }
}
