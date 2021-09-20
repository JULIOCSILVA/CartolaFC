using System.Collections.Generic;

namespace Cartola.Domain.Entidades
{
    public class Atletas
    {
        public Posicao posicao { get; set; }
        public string apelido { get; set; }
        public string foto { get; set; }
        public int posicao_id { get; set; }
        public string FotoReplace
        {
            get { return string.IsNullOrEmpty(foto) ? string.Empty : foto.Replace("FORMATO", "50x50"); }
        }
        public Dictionary<string, string> scout { get; set; }
        public bool Capitao { get; set; }
        public int capitao_id { get; set; }
        public string nome { get; set; }
        public string slug { get; set; }
        public int atleta_id { get; set; }
        public string rodada_id { get; set; }
        public string clube_id { get; set; }
        public string status_id { get; set; }
        public string pontos_num { get; set; }
        public string preco_num { get; set; }
        public string variacao_num { get; set; }
        public string media_num { get; set; }
        public string jogos_num { get; set; }
        public decimal pontuacao { get; set; }
        public string Scouts { get; set; }
    }

    public class Scout
    {
        public string A { get; set; }
        public string DS { get; set; }
        public string FC { get; set; }
        public string PI { get; set; }
        public string FD { get; set; }
        public string FS { get; set; }
        public string G { get; set; }
        public string SG { get; set; }
        public string FF { get; set; }
        public string CA { get; set; }
        public string I { get; set; }
        public string PS { get; set; }
        public string DE { get; set; }
    }

}
