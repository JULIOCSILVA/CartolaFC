namespace Cartola.Domain.Entidades
{
    public class Liga
    {
        public int liga_id { get; set; }
        public object time_dono_id { get; set; }
        public object clube_id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string slug { get; set; }
        public string tipo { get; set; }
        public bool mata_mata { get; set; }
        public bool editorial { get; set; }
        public bool patrocinador { get; set; }
        public string criacao { get; set; }
        public bool sem_capitao { get; set; }
        public int tipo_flamula { get; set; }
        public object tipo_estampa_flamula { get; set; }
        public object tipo_adorno_flamula { get; set; }
        public string cor_primaria_estampa_flamula { get; set; }
        public string cor_secundaria_estampa_flamula { get; set; }
        public object cor_borda_flamula { get; set; }
        public object cor_fundo_flamula { get; set; }
        public string url_flamula_svg { get; set; }
        public string url_flamula_png { get; set; }
        public object tipo_trofeu { get; set; }
        public object cor_trofeu { get; set; }
        public object url_trofeu_svg { get; set; }
        public object url_trofeu_png { get; set; }
        public int inicio_rodada { get; set; }
        public object fim_rodada { get; set; }
        public object quantidade_times { get; set; }
        public bool sorteada { get; set; }
        public string imagem { get; set; }
        public object mes_ranking_num { get; set; }
        public object mes_variacao_num { get; set; }
        public object camp_ranking_num { get; set; }
        public object camp_variacao_num { get; set; }
        public object capitao_ranking_num { get; set; }
        public object capitao_variacao_num { get; set; }
        public int total_times_liga { get; set; }
        public object vagas_restantes { get; set; }
        public int total_amigos_na_liga { get; set; }
    }


}
