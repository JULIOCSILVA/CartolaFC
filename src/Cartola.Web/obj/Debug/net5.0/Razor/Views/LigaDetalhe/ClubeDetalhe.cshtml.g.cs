#pragma checksum "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d68a59edcf1b0d54c3075d7684c1e51730c79de3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LigaDetalhe_ClubeDetalhe), @"mvc.1.0.view", @"/Views/LigaDetalhe/ClubeDetalhe.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\_ViewImports.cshtml"
using Cartola.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\_ViewImports.cshtml"
using Cartola.Web.ViewModel.LigaSimples;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\_ViewImports.cshtml"
using Cartola.Web.ViewModel.LigaDetalhe;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d68a59edcf1b0d54c3075d7684c1e51730c79de3", @"/Views/LigaDetalhe/ClubeDetalhe.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"537000f1d4ef17f0bdab75dde1573268ca0776de", @"/Views/_ViewImports.cshtml")]
    public class Views_LigaDetalhe_ClubeDetalhe : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ClubeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
  
    ViewData["Title"] = "Cartola";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>

    $(function () {

        // hide all the toggable rows on page load
        $('.more').closest('tr').next().css('display', 'none');
        $('.more').unbind().click(function () {
            var elem = $(this).closest('tr').next();
            elem.toggle();
        });

    });

</script>

<div class=""time"">
    <div class=""brasao"">
        <img");
            BeginWriteAttribute("src", " src=\"", 450, "\"", 466, 1);
#nullable restore
#line 24 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
WriteAttributeValue("", 456, Model.Url, 456, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"max-height: 64.05px;\" />\r\n        <p>\r\n            <label>");
#nullable restore
#line 26 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
              Write(Model.NomeTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n        </p>\r\n    </div>\r\n    <table>\r\n        <tr>\r\n            <td class=\"EsquerdaTexto\">\r\n                <label><b>Cartoleiro: </b></label>\r\n            </td>\r\n            <td class=\"DireitaTexto\">\r\n                <label>");
#nullable restore
#line 35 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
                  Write(Model.NomeCartoleiro);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td class=\"EsquerdaTexto\">\r\n                <b>Parcial: </b>\r\n            </td>\r\n            <td class=\"DireitaTexto\">\r\n                <label");
            BeginWriteAttribute("style", " style=\"", 1017, "\"", 1101, 2);
            WriteAttributeValue("", 1025, "color:", 1025, 6, true);
#nullable restore
#line 43 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
WriteAttributeValue(" ", 1031, Convert.ToDecimal(Model.Pontos.rodada) < 0 ? "#ffffff" : "#28cc00", 1032, 69, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 43 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
                                                                                                       Write(Math.Round(Model.Pontos.rodada.Value, 2).ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                <label");
            BeginWriteAttribute("style", " style=\"", 1187, "\"", 1252, 2);
            WriteAttributeValue("", 1195, "color:", 1195, 6, true);
#nullable restore
#line 44 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
WriteAttributeValue(" ", 1201, Model.PosicaoRodada < 0 ? "#ffffff" : "#28cc00", 1202, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">(");
#nullable restore
#line 44 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
                                                                                     Write(Model.PosicaoRodada.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(" º)</label>\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td class=\"EsquerdaTexto\">\r\n                <b>Tot. Parcial: </b>\r\n            </td>\r\n            <td class=\"DireitaTexto\">\r\n                ");
#nullable restore
#line 52 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
           Write(Html.Label("Label6", Math.Round(Model.Pontos.campeonato.HasValue ? Model.Pontos.campeonato.Value : 0, 2).ToString(), new { style = "color:" + ((Model.Pontos.campeonato.HasValue ? Model.Pontos.campeonato.Value : 0) < 0 ? "#ffffff" : "#28cc00").ToString() }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 53 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
           Write(Html.Label("Label6", "(" + Model.PosicaoCampeonatoParcial.ToString() + "º)", new { style = "color:" + (Model.Diferenca < 0 ? "#9e0000" : "#28cc00").ToString() }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td class=\"EsquerdaTexto\">\r\n                <b>Tot. Anterior: </b>\r\n            </td>\r\n            <td class=\"DireitaTexto\">\r\n                ");
#nullable restore
#line 61 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
           Write(Html.Label("Label4", Math.Round(Model.UltimaPontuacaoTotal, 2).ToString(), new { style = "color:" + (Model.UltimaPontuacaoTotal < 0 ? "#ffffff" : "#28cc00").ToString() }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 62 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
           Write(Html.Label("Label7", "(" + Model.PosicaoCampeonato.ToString() + "º)", new { style = "color:" + (Model.UltimaPontuacao < 0 ? "#ffffff" : "#28cc00").ToString() }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n        <tr>\r\n            <td class=\"EsquerdaTexto\">\r\n                <b>Últ. Rodada: </b>\r\n            </td>\r\n            <td class=\"DireitaTexto\">\r\n                ");
#nullable restore
#line 70 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
           Write(Html.Label("Label2", Model.UltimaPontuacao.ToString("N2"), new { style = "color:" + (Model.UltimaPontuacao < 0 ? "#ffffff" : "#28cc00").ToString() }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n        <tr class=\"ultimaLinhaTabela\">\r\n            <td class=\"EsquerdaTexto\">\r\n                <b>Patrimônio: </b>\r\n            </td>\r\n            <td class=\"DireitaTexto\">\r\n                ");
#nullable restore
#line 78 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
           Write(Html.Label("Label3", Model.Patrimonio.ToString("N2"), new { style = "color:" + (Model.Patrimonio < 0 ? "#ffffff" : "#28cc00").ToString() }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </td>\r\n        </tr>\r\n    </table>\r\n    <br />\r\n    <div>\r\n        <asp:ListView runat=\"server\" ID=\"rptJogador\">\r\n");
#nullable restore
#line 86 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
             foreach (var atleta in Model.Atletas)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <ItemTemplate>\r\n                    <table class=\"jogadores\">\r\n");
#nullable restore
#line 90 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
                         if (atleta.Capitao)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr class=\"more capitao\">\r\n                                <td style=\"width: 10%;\">\r\n                                    <img");
            BeginWriteAttribute("src", " src=\"", 3712, "\"", 3737, 1);
#nullable restore
#line 94 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
WriteAttributeValue("", 3718, atleta.FotoReplace, 3718, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                </td>\r\n                                <td style=\"width: 80%; text-align: left;\">\r\n                                    ");
#nullable restore
#line 97 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
                               Write(Html.Label("lblApelido", atleta.apelido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td style=\"width: 10%; text-align: right;\">\r\n                                    ");
#nullable restore
#line 100 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
                               Write(Html.Label("Label1", atleta.pontuacao.ToString("N2"), new { style = "color:" + (atleta.pontuacao < 0 ? "#9e0000" : "#28cc00").ToString() }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 103 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr class=\"more\">\r\n                                <td style=\"width: 10%;\">\r\n                                    <img");
            BeginWriteAttribute("src", " src=\"", 4534, "\"", 4559, 1);
#nullable restore
#line 108 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
WriteAttributeValue("", 4540, atleta.FotoReplace, 4540, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                </td>\r\n                                <td style=\"width: 80%; text-align: left;\">\r\n                                    ");
#nullable restore
#line 111 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
                               Write(Html.Label("lblApelido", atleta.apelido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td style=\"width: 10%; text-align: right;\">\r\n                                    ");
#nullable restore
#line 114 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
                               Write(Html.Label("Label1", atleta.pontuacao.ToString("N2"), new { style = "color:" + (atleta.pontuacao < 0 ? "#9e0000" : "#28cc00").ToString() }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 117 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <tr>
                            <td colspan=""3"">
                                <div id=""divHidden"">
                                    <span id=""Label12"" style=""white-space: pre-line"">
                                        ");
#nullable restore
#line 122 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
                                   Write(Html.Raw(Html.Encode(atleta.Scouts).Replace("\n", "<br/>")));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </span>\r\n\r\n                                </div>\r\n                            </td>\r\n                        </tr>\r\n                    </table>\r\n                </ItemTemplate>\r\n");
#nullable restore
#line 130 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </asp:ListView>\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 134 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
 if (@Model.index % 3 == 0) 
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <hr />\r\n");
#nullable restore
#line 137 "D:\Cursos\CartolaFC\JULIOCSILVA\CartolaFC\src\Cartola.Web\Views\LigaDetalhe\ClubeDetalhe.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ClubeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
