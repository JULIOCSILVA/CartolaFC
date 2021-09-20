using Cartola.Domain.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cartola.Web.ViewModel.LigaDetalhe
{
    public class ClubeViewModel
    {
        public ClubeViewModel()
        {
            Atletas = new List<Atletas>();
            AtletasPontuacao = new List<Atletas>();
            Rodadas = new List<SelectListItem>();
        }

        public int rodada_id { get; set; }
        public int capitao_id { get; set; }
        public int time_id { get; set; }
        public bool sem_capitao { get; set; }
        public Pontos Pontos { get; set; }
        public string Url { get; set; }
        public string NomeTime { get; set; }
        public string Slug { get; set; }
        public string NomeCartoleiro { get; set; }
        public decimal UltimaPontuacao { get; set; }
        public decimal UltimaPontuacaoTotal { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999999999999999.99)]
        public decimal Patrimonio { get; set; }
        public string CorFundo { get; set; }
        public string CorFrente { get; set; }
        public int PosicaoRodada { get; set; }
        public int PosicaoCampeonato { get; set; }

        public int PosicaoCampeonatoParcial { get; set; }

        public int Diferenca
        {
            get
            {
                return PosicaoCampeonato - PosicaoCampeonatoParcial;
            }
        }
        public int index { get; set; }
        public bool BlMercadoAberto { get; set; }
        public string JsonData { get; set; }
        public List<Atletas> Atletas { get; set; }
        public List<Atletas> AtletasPontuacao { get; set; }
        public List<SelectListItem> Rodadas { get; set; }

        internal void CarregarRodadas(int rodada_atual)
        {
            for (int i = rodada_atual; i >= 1; i--)
            {
                Rodadas.Add(new SelectListItem { Value = i.ToString(), Text = $"Rodada: {i}" });
            }
        }
    }
}
