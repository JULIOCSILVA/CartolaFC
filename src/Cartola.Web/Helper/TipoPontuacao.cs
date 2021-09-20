using System;

namespace Cartola.Web.Helper
{
    public class TipoPontuacao
    {
        public static string RetornaDescricao(string codigo)
        {
            switch (codigo)
            {
                case "G":
                    return "GOL";
                case "A":
                    return "ASSISTÊNCIA";
                case "FT":
                    return "FINALIZAÇÃO NA TRAVE";
                case "FD":
                    return "FINALIZAÇÃO DEFENDIDA";
                case "FF":
                    return "FINALIZAÇÃO PRA FORA";
                case "FS":
                    return "FALTA SOFRIDA";
                case "PP":
                    return "PÊNALTI PERDIDO";
                case "I":
                    return "IMPEDIMENTO";
                case "PI":
                    return "PASSE IMCOMPLETO";
                case "SG":
                    return "JOGOS SEM SOFRER GOL";
                case "DP":
                    return "DEFESA DE PÊNALTI";
                case "DD":
                    return "DEFESA DIFÍCIL";
                case "DS":
                    return "DESARME";
                case "GC":
                    return "GOL CONTRA";
                case "CV":
                    return "CARTÃO VERMELHO";
                case "CA":
                    return "CARTÃO AMARELO";
                case "GS":
                    return "GOL SOFRIDO";
                case "FC":
                    return "FALTA COMETIDA";
                default:
                    return "";
            }
        }

        public static string RetornaPontuacao(string tipo, int quantidade)
        {
            string valor = string.Empty;
            switch (tipo)
            {
                case "G":
                    valor = Convert.ToString(quantidade * 8);
                    break;
                case "A":
                    valor = Convert.ToString(quantidade * 5);
                    break;
                case "FT":
                    valor = Convert.ToString(quantidade * 3.0);
                    break;
                case "FD":
                    valor = Convert.ToString(quantidade * 1.2);
                    break;
                case "FF":
                    valor = Convert.ToString(quantidade * 0.8);
                    break;
                case "FS":
                    valor = Convert.ToString(quantidade * 0.5);
                    break;
                case "PP":
                    valor = Convert.ToString(quantidade * -4);
                    break;
                case "I":
                    valor = Convert.ToString(quantidade * -0.5);
                    break;
                case "PI":
                    valor = Convert.ToString(Math.Round(quantidade * -0.1, 2, MidpointRounding.AwayFromZero));
                    break;
                case "SG":
                    valor = Convert.ToString(quantidade * 5);
                    break;
                case "DP":
                    valor = Convert.ToString(quantidade * 7);
                    break;
                case "DD":
                    valor = Convert.ToString(quantidade * 4);
                    break;
                case "DS":
                    valor = Convert.ToString(quantidade * 1);
                    break;
                case "GC":
                    valor = Convert.ToString(quantidade * -5);
                    break;
                case "CV":
                    valor = Convert.ToString(quantidade * -5);
                    break;
                case "CA":
                    valor = Convert.ToString(quantidade * -2);
                    break;
                case "GS":
                    valor = Convert.ToString(quantidade * -2);
                    break;
                case "FC":
                    valor = Convert.ToString(quantidade * -0.5);
                    break;

            }

            return valor;
        }
    }
}
