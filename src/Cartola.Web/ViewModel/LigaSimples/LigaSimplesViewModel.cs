using Cartola.Domain.Entidades;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cartola.Web.ViewModel.LigaSimples
{
    public class LigaSimplesViewModel
    {
        public LigaSimplesViewModel()
        {
            Clubes = new List<Clube>();
            JogadorPontuacao = new List<Atletas>();
        }

        public string nome { get; set; }
        public string descricao { get; set; }
        public string url_flamula_svg { get; set; }
        public List<Atletas> JogadorPontuacao { get; set; }
        public bool BlMercadoAberto { get; set; }
        public int Rodada { get; set; }
        public List<Clube> Clubes { get; set; }

        [Required]
        public string slug { get; set; }
    }
}
