using Cartola.Domain.Entidades;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cartola.Infra.Interface
{
    public interface IClientApiCartola
    {
        [Get("/BuscarInformacaoLiga")]
        Task<ApiResponse<Root>> BuscarInformacaoLiga(string slug);

        [Get("/VerificarRodada")]
        Task<ApiResponse<Rodada>> VerificarRodada();

        [Get("/AtletasPontuados")]
        Task<ApiResponse<List<Atletas>>> RetornaAtletasPontuados();

        [Get("/RetornaTimePorIdRodada")]
        Task<ApiResponse<ClubeDetalhe>> RetornaTimePorIdRodada(int time_id, int rodada);
    }
}
