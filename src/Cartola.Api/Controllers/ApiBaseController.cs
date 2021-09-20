using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Cartola.Api.Controllers
{
    public class ApiBaseController : ControllerBase
    {
        public ApiBaseController()
        {
            SSLIgnore();
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        }

        protected static HttpClientHandler SSLIgnore() => new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };

        protected static Encoding BuscaEncoding()
        {
            return Encoding.UTF8;
        }

        protected static string RecuperaToken(IConfiguration configuration)
        {
            //var HeadersHttp = new
            //{
            //    ContentType = "Content-Type",
            //    ContentValue = "application/json",
            //    UserAgent = "User-Agent",
            //    UserAgetValue = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)",
            //    TokenGlb = "X-GLB-Token"
            //};

            ///* url com endpoints */
            ////var UrlApiCFC = "https://api.cartolafc.globo.com";
            ///* url para login */
            //var UrlApiLogin = "https://login.globo.com/api/authentication";
            ///* objeto com os dados de retorno do login */
            //var retorno_acesso = new Authentication();
            ///* objeto que será enviado solicitando o token de autorização de acesso */
            //var credenciais_acesso = new { payload = new { email = "email@gmail.com", password = "SenhaCartola", serviceId = 4728 } };

            //using (var wc = new WebClient())
            //{
            //    wc.Headers.Add(HeadersHttp.ContentType, HeadersHttp.ContentValue);
            //    wc.Headers.Add(HeadersHttp.UserAgent, HeadersHttp.UserAgetValue);

            //    retorno_acesso = JsonConvert.DeserializeObject<Authentication>(wc.UploadString(UrlApiLogin, "POST", JsonConvert.SerializeObject(credenciais_acesso)));
            //}

            var glbId = configuration.GetSection("GlbId").Value;
            return glbId;
        }

    }
}
