using System.Collections.Generic;

namespace Cartola.Domain.Entidades
{
    public class ClubeDetalhe
    {
        public List<Posicao> PosicoesPC { get; set; }
        public List<Atletas> atletas { get; set; }
        public List<Reserva> reservas { get; set; }
        public TimeDetalhe time { get; set; }
        public double pontos_campeonato { get; set; }
        public int capitao_id { get; set; }
        public double pontos { get; set; }
        public int esquema_id { get; set; }
        public int rodada_atual { get; set; }
        public double patrimonio { get; set; }
        public int valor_time { get; set; }
        public RankingClubeDetalhe ranking { get; set; }
    }

    public class Reserva
    {
        public object scout { get; set; }
        public int atleta_id { get; set; }
        public int rodada_id { get; set; }
        public int clube_id { get; set; }
        public int posicao_id { get; set; }
        public int status_id { get; set; }
        public double pontos_num { get; set; }
        public double preco_num { get; set; }
        public double variacao_num { get; set; }
        public double media_num { get; set; }
        public int jogos_num { get; set; }
        public string slug { get; set; }
        public string apelido { get; set; }
        public string apelido_abreviado { get; set; }
        public string nome { get; set; }
        public string foto { get; set; }
    }

    public class TimeDetalhe
    {
        public int temporada_inicial { get; set; }
        public string nome_cartola { get; set; }
        public string cor_camisa { get; set; }
        public string cor_borda_escudo { get; set; }
        public string foto_perfil { get; set; }
        public string cor_fundo_escudo { get; set; }
        public string globo_id { get; set; }
        public string nome { get; set; }
        public string url_escudo_svg { get; set; }
        public string url_escudo_png { get; set; }
        public string url_camisa_svg { get; set; }
        public string url_camisa_png { get; set; }
        public string slug { get; set; }
        public string cor_primaria_estampa_escudo { get; set; }
        public string cor_secundaria_estampa_escudo { get; set; }
        public object sorteio_pro_num { get; set; }
        public string cor_primaria_estampa_camisa { get; set; }
        public string cor_secundaria_estampa_camisa { get; set; }
        public int rodada_time_id { get; set; }
        public object facebook_id { get; set; }
        public int tipo_camisa { get; set; }
        public int tipo_escudo { get; set; }
        public int time_id { get; set; }
        public int tipo_adorno { get; set; }
        public int esquema_id { get; set; }
        public int tipo_estampa_camisa { get; set; }
        public int tipo_estampa_escudo { get; set; }
        public int patrocinador1_id { get; set; }
        public int clube_id { get; set; }
        public int patrocinador2_id { get; set; }
        public bool lgpd_quarentena { get; set; }
        public bool assinante { get; set; }
        public bool simplificado { get; set; }
        public bool cadastro_completo { get; set; }
        public bool lgpd_removido { get; set; }
    }

    public class Atual
    {
        public int ranking_id { get; set; }
        public int mes { get; set; }
        public int posicao { get; set; }
    }

    public class Anterior
    {
        public int ranking_id { get; set; }
        public int mes { get; set; }
        public int posicao { get; set; }
    }

    public class RankingClubeDetalhe
    {
        public Atual atual { get; set; }
        public Anterior anterior { get; set; }
        public int melhor_ranking_id { get; set; }
    }

    public class Posicao
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string abreviacao { get; set; }
    }
}
