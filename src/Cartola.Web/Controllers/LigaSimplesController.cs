using Cartola.Domain.Entidades;
using Cartola.Helper.Enumeradores;
using Cartola.Helper.Extensions;
using Cartola.Infra.Interface;
using Cartola.Web.Helper;
using Cartola.Web.ViewModel.LigaDetalhe;
using Cartola.Web.ViewModel.LigaSimples;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cartola.Web.Controllers
{
    public class LigaSimplesController : Controller
    {
        private readonly IClientApiCartola _clientApiCartola;

        public LigaSimplesController(IClientApiCartola clientApiCartola)
        {
            _clientApiCartola = clientApiCartola;
        }

        public async Task<IActionResult> Index(string slug)
        {
            slug = slug?.Replace(" ", "-").ToLower().Trim();
            var model = new LigaSimplesViewModel();

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

                        model.JogadorPontuacao = responseAtletaPontuado.Content;
                    }
                }

                foreach (var time in times)
                    AdicionaClube(model, liga, time);

                AjustaPosicaoTabela(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> ClubeDetalhe(int time_id, string rodada_id)
        {
            var viewModel = new ClubeViewModel();
            try
            {
                var atualizacaoAtletas = new List<Atletas>();

                var responseMercado = await _clientApiCartola.VerificarRodada();
                if (!responseMercado.IsSuccessStatusCode)
                    throw new Exception("Erro ao buscar informação do mercado");
                viewModel.CarregarRodadas(responseMercado.Content.rodada_atual);

                var responseAtletaPontuado = await _clientApiCartola.RetornaAtletasPontuados();
                if (!responseAtletaPontuado.IsSuccessStatusCode)
                    throw new Exception("Erro ao buscar informação de jogador pontuado");
                var atletasPontuados = responseAtletaPontuado.Content;

                var responseClube = await _clientApiCartola.RetornaTimePorIdRodada(time_id, Convert.ToInt32(rodada_id));
                if (!responseClube.IsSuccessStatusCode)
                    throw new Exception("Erro ao buscar informações do clube");

                var clube = responseClube.Content;

                foreach (var atleta in clube.atletas)
                {
                    var atletaPontuado = atletasPontuados.FirstOrDefault(a => a.atleta_id == atleta.atleta_id);
                    //Adiciona na lista caso o Jogador já tenha entrado em campo
                    if (atletaPontuado != null)
                    {
                        atletaPontuado.Capitao = atleta.atleta_id == clube.capitao_id;
                        atletaPontuado.pontuacao *= atletaPontuado.Capitao ? 2 : 1;
                        atletaPontuado.posicao = new Posicao { abreviacao = EnumExtensions.GetDescription((TipoPosicao)atletaPontuado.posicao_id) };
                        PreencheScouts(atletaPontuado);

                        atualizacaoAtletas.Add(atletaPontuado);
                    }
                    else //Adiciona na lista caso o jogador não tenha entrado em campo
                    {
                        atleta.Capitao = atleta.atleta_id == clube.capitao_id;
                        atleta.pontuacao *= atleta.Capitao ? 2 : 1;
                        atleta.posicao = new Posicao { abreviacao = EnumExtensions.GetDescription((TipoPosicao)atleta.posicao_id) };
                        PreencheScouts(atleta);
                        atualizacaoAtletas.Add(atleta);
                    }
                }

                viewModel.Slug = clube.time.slug;
                viewModel.NomeTime = clube.time.nome;
                viewModel.NomeCartoleiro = clube.time.nome_cartola;
                viewModel.Url = clube.time.url_escudo_png;
                viewModel.Pontos = new Pontos() { rodada = Convert.ToDecimal(atualizacaoAtletas.Sum(a => a.pontuacao)) };
                viewModel.Patrimonio = Convert.ToDecimal(clube.patrimonio);
                viewModel.index = viewModel.index;
                viewModel.Atletas = atualizacaoAtletas.OrderBy(q => q.posicao_id).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return View("ClubeDetalhe", viewModel);
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

        private static void AjustaPosicaoTabela(LigaSimplesViewModel model)
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

        private static void AdicionaClube(LigaSimplesViewModel model, Liga liga, Time time)
        {
            Clube clube = new Clube
            {
                Slug = time.slug,
                NomeTime = time.nome,
                NomeCartoleiro = time.nome_cartola,
                Url = time.url_escudo_png,
                Pontos = time.pontos,
                sem_capitao = liga.sem_capitao,
                time_id = time.time_id
            };

            if (model.JogadorPontuacao != null)
                clube.Pontos.rodada = model.JogadorPontuacao.Where(x => clube.Atletas.Any(y => y.atleta_id == x.atleta_id)).Sum(x => x.pontuacao);

            if (!clube.BlMercadoAberto)
                clube.Pontos.campeonato = clube.Pontos.campeonato != null ? clube.Pontos.campeonato + clube.Pontos.rodada : clube.Pontos.rodada;

            clube.Patrimonio = Convert.ToDecimal(time.patrimonio);
            clube.UltimaPontuacao = time.pontos.rodada.HasValue ? time.pontos.rodada.Value : 0;
            clube.UltimaPontuacaoTotal = Convert.ToDecimal(clube.Pontos.campeonato) - clube.UltimaPontuacao;

            model.Clubes.Add(clube);
        }
    }
}
