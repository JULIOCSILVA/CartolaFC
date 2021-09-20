using System;
using System.Collections.Generic;
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
        public decimal UltimaPontuacaoTotal { get; set; }
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
    }
}
