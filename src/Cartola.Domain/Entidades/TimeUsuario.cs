namespace Cartola.Domain.Entidades
{
    public class TimeUsuario
    {
        public string url_escudo_png { get; set; }
        public string url_escudo_svg { get; set; }
        public string nome_cartola { get; set; }
        public string slug { get; set; }
        public string foto_perfil { get; set; }
        public string nome { get; set; }
        public object facebook_id { get; set; }
        public int time_id { get; set; }
        public bool assinante { get; set; }
        public bool lgpd_removido { get; set; }
        public bool lgpd_quarentena { get; set; }
        public int patrimonio { get; set; }
        public Ranking ranking { get; set; }
        public Pontos pontos { get; set; }
        public Variacao variacao { get; set; }
    }


}
