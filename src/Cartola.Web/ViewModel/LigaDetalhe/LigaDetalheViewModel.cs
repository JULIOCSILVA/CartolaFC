using Cartola.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cartola.Web.ViewModel.LigaDetalhe
{
    public class LigaDetalheViewModel
    {
        public LigaDetalheViewModel()
        {
            Clubes = new List<Clube>();
            AtletasPontuacao = new List<Atletas>();
        }

        public string nome { get; set; }
        public string descricao { get; set; }
        public string url_flamula_svg { get; set; }
        public List<Atletas> AtletasPontuacao { get; set; }
        public bool BlMercadoAberto { get; set; }
        public int Rodada { get; set; }
        public List<Clube> Clubes { get; set; }
        [Required]
        public string slug { get; set; }
    }
}
