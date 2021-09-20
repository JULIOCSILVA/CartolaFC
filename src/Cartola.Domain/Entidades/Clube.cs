using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartola.Domain.Entidades
{
    public class Clube
    {
        public Clube()
        {
            Atletas = new List<Atletas>();
            AtletasPontuacao = new List<Atletas>();
        }

        public int capitao_id { get; set; }
        public int time_id { get; set; }
        public bool sem_capitao { get; set; }
        public Pontos Pontos { get; set; }
        public string Url { get; set; }
        public string NomeTime { get; set; }
        public string Slug { get; set; }
        public string NomeCartoleiro { get; set; }
        public decimal UltimaPontuacao { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 9999999999999999.99)]
        public decimal Patrimonio { get; set; }
        public string CorFundo { get; set; }
        public string CorFrente { get; set; }
        public int PosicaoRodada { get; set; }
        public int PosicaoCampeonato { get; set; }
        public int PosicaoCampeonatoParcial { get; set; }
        public int index { get; set; }
        public bool BlMercadoAberto { get; set; }
        public string JsonData { get; set; }
        public List<Atletas> Atletas { get; set; }
        public List<Atletas> AtletasPontuacao { get; set; }

        public int Diferenca
        {
            get
            {
                return PosicaoCampeonato - PosicaoCampeonatoParcial;
            }
        }

        public decimal? PontuacaoTotal
        {
            get
            {
                if (BlMercadoAberto)
                    return Pontos.campeonato.HasValue ? Pontos.campeonato : Pontos.rodada;
                else
                    return Pontos.campeonato.HasValue ? Pontos.campeonato + Pontos.rodada : Pontos.rodada;
            }
        }

        public decimal? PontuacaoRodada
        {
            get
            {
                if (AtletasPontuacao.Count > 0)
                    return AtletasPontuacao.Where(x => Atletas.Any(y => y.atleta_id == x.atleta_id)).Sum(x => (x.atleta_id == capitao_id ? x.pontuacao * 2 : x.pontuacao));
                else
                    return Atletas.Sum(x => (x.atleta_id == capitao_id ? x.pontos_num * 2 : x.pontos_num)); ;
            }
        }

        public decimal UltimaPontuacaoTotal
        {
            get
            {
                return Convert.ToDecimal(Pontos.campeonato) - UltimaPontuacao;
            }
        }
    }
}
