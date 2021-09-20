using Cartola.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace Cartola.Api.Controllers
{
    [Route("api/cartola")]
    [ApiController]
    public class CartolaController : ApiBaseController
    {
        private readonly IConfiguration _configuration;

        public CartolaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("/VerificarRodada")]
        public IActionResult VerificarRodada([FromServices] IDistributedCache cache)
        {
            string valorJSON = cache.GetString("VerificarRodada");
            if (valorJSON == null)
            {
                try
                {
                    HttpWebRequest requestStatus = WebRequest.Create(_configuration.GetSection("UrlApiMercado").Value) as HttpWebRequest;
                    requestStatus.UserAgent = _configuration.GetSection("UserAgent").Value;
                    HttpWebResponse responseStatus = (HttpWebResponse)requestStatus.GetResponse();

                    WebHeaderCollection headerStatus = responseStatus.Headers;
                    string response = string.Empty;
                    using (var reader = new System.IO.StreamReader(responseStatus.GetResponseStream(), BuscaEncoding()))
                    {
                        valorJSON = reader.ReadToEnd();
                    }

                    DistributedCacheEntryOptions opcoesCache = new DistributedCacheEntryOptions();
                    opcoesCache.SetAbsoluteExpiration(TimeSpan.FromMinutes(1440));

                    cache.SetString("VerificarRodada", valorJSON, opcoesCache);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return Content(valorJSON, "application/json");
        }

        [HttpGet("/AtletasPontuados")]
        public IActionResult RetornaAtletasPontuados([FromServices] IDistributedCache cache)
        {
            string valorJSON = cache.GetString("AtletasPontuados");
            if (valorJSON == null)
            {
                try
                {
                    var atletasPontuados = new List<Atletas>();

                    HttpWebRequest requestPontucao = WebRequest.Create(_configuration.GetSection("UrlApiAtletasPontuados").Value) as HttpWebRequest;
                    requestPontucao.UserAgent = _configuration.GetSection("UserAgent").Value;
                    HttpWebResponse responsePontucao = (HttpWebResponse)requestPontucao.GetResponse();
                    string response = string.Empty;
                    using (var reader = new System.IO.StreamReader(responsePontucao.GetResponseStream(), BuscaEncoding()))
                    {
                        response = reader.ReadToEnd();
                    }

                    if (!string.IsNullOrEmpty(response))
                    {
                        Dictionary<string, object> personsPontucao = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);
                        Dictionary<string, object> jogadores = JsonConvert.DeserializeObject<Dictionary<string, object>>(personsPontucao["atletas"].ToString());

                        foreach (var item in jogadores)
                        {
                            var atleta = JsonConvert.DeserializeObject<Atletas>(item.Value.ToString());
                            atleta.atleta_id = Convert.ToInt32(item.Key);
                            atletasPontuados.Add(atleta);
                        }
                    }

                    valorJSON = JsonConvert.SerializeObject(atletasPontuados);

                    DistributedCacheEntryOptions opcoesCache = new DistributedCacheEntryOptions();
                    opcoesCache.SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

                    cache.SetString("AtletasPontuados", valorJSON, opcoesCache);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return Content(valorJSON, "application/json");
        }

        [HttpGet("/BuscarInformacaoLiga")]
        public IActionResult BuscarInformacaoLiga([FromServices] IDistributedCache cache, string slug)
        {
            string valorJSON = cache.GetString($"BuscarInformacaoLiga{slug}");
            if (valorJSON == null)
            {
                string responseText = string.Empty;

                if (string.IsNullOrEmpty(responseText))
                {
                    HttpWebRequest request = WebRequest.Create($"{_configuration.GetSection("UrlApiBuscarLiga").Value}/{slug}") as HttpWebRequest;
                    request.UserAgent = _configuration.GetSection("UserAgent").Value;
                    request.Headers.Add("X-GLB-Token", RecuperaToken(_configuration));

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    using (var reader = new System.IO.StreamReader(response.GetResponseStream(), BuscaEncoding()))
                    {
                        valorJSON = reader.ReadToEnd();
                    }

                    DistributedCacheEntryOptions opcoesCache = new DistributedCacheEntryOptions();
                    opcoesCache.SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

                    cache.SetString($"BuscarInformacaoLiga{slug}", valorJSON, opcoesCache);
                }
            }

            return Content(valorJSON, "application/json");
        }

        [HttpGet("/RetornaTimePorIdRodada")]
        public IActionResult RetornaTimePorIdRodada([FromServices] IDistributedCache cache, int time_id, int rodada)
        {
            string valorJSON = cache.GetString($"RetornaTimePorIdRodada{time_id}{rodada}");
            if (valorJSON == null)
            {
                var url = $"{_configuration.GetSection("UrlApiBurcarTime").Value}/{time_id}" + (rodada > 0 ? $"/{rodada}" : string.Empty);

                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.UserAgent = _configuration.GetSection("UserAgent").Value;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string responseText = string.Empty;
                using (var reader = new System.IO.StreamReader(response.GetResponseStream(), BuscaEncoding()))
                {
                    responseText = reader.ReadToEnd();
                }

                var clubeRetorno = JsonConvert.DeserializeObject<ClubeDetalhe>(responseText);
                valorJSON = JsonConvert.SerializeObject(clubeRetorno);

                DistributedCacheEntryOptions opcoesCache = new DistributedCacheEntryOptions();
                opcoesCache.SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
                cache.SetString($"RetornaTimePorIdRodada{time_id}{rodada}", valorJSON, opcoesCache);
            }

            return Content(valorJSON, "application/json");
        }
    }
}
