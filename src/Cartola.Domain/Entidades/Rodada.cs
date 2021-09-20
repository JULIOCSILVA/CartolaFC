using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartola.Domain.Entidades
{
    public class Rodada
    {
        public int rodada_atual { get; set; }
        public int status_mercado { get; set; }
        public int esquema_default_id { get; set; }
        public int cartoleta_inicial { get; set; }
        public int max_ligas_free { get; set; }
        public int max_ligas_pro { get; set; }
        public int max_ligas_matamata_free { get; set; }
        public int max_ligas_matamata_pro { get; set; }
        public int max_ligas_patrocinadas_free { get; set; }
        public int max_ligas_patrocinadas_pro_num { get; set; }
        public bool game_over { get; set; }
        public int temporada { get; set; }
        public bool reativar { get; set; }
        public bool exibe_sorteio_pro { get; set; }
        public Fechamento fechamento { get; set; }
        public LimitesCompeticao limites_competicao { get; set; }
        public int times_escalados { get; set; }
        public bool mercado_pos_rodada { get; set; }
        public bool novo_mes_ranking { get; set; }
    }

    public class Fechamento
    {
        public int dia { get; set; }
        public int mes { get; set; }
        public int ano { get; set; }
        public int hora { get; set; }
        public int minuto { get; set; }
        public int timestamp { get; set; }
    }

    public class LimitesCompeticao
    {
        public int total_confronto_pro { get; set; }
        public int total_confronto_free { get; set; }
        public int criacao_confronto_pro { get; set; }
        public int criacao_confronto_free { get; set; }
    }
}
