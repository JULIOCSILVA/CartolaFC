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
                    return "PASSE INCOMPLETO";
                case "PC":
                    return "PASSE COMETIDO";
                case "PS":
                    return "PENALTI SOFRIDO";
                case "SG":
                    return "JOGOS SEM SOFRER GOL";
                case "DP":
                    return "DEFESA DE PÊNALTI";
                case "DE":
                    return "DEFESA";
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

        public static double RetornaPontuacao(string tipo, int quantidade)
        {
            double valor = 0.00;
            switch (tipo)
            {
                case "G":
                    valor = quantidade * 8.00;
                    break;
                case "A":
                    valor = quantidade * 5.00;
                    break;
                case "FT":
                    valor = quantidade * 3.00;
                    break;
                case "FD":
                    valor = quantidade * 1.20;
                    break;
                case "FF":
                    valor = quantidade * 0.80;
                    break;
                case "FS":
                    valor = quantidade * 0.50;
                    break;
                case "PS":
                    valor = quantidade * 1.00;
                    break;
                case "PP":
                    valor = quantidade * -4.00;
                    break;
                case "PC":
                    valor = quantidade * -1.00;
                    break;
                case "I":
                    valor = quantidade * -0.50;
                    break;
                case "PI":
                    valor = quantidade * -0.10;
                    break;
                case "SG":
                    valor = quantidade * 5.00;
                    break;
                case "DP":
                    valor = quantidade * 7.00;
                    break;
                case "DE":
                    valor = quantidade * 1.00;
                    break;
                case "DS":
                    valor = quantidade * 1.00;
                    break;
                case "GC":
                    valor = quantidade * -5.00;
                    break;
                case "CV":
                    valor = quantidade * -5.00;
                    break;
                case "CA":
                    valor = quantidade * -2.00;
                    break;
                case "GS":
                    valor = quantidade * -1.00;
                    break;
                case "FC":
                    valor = quantidade * -0.50;
                    break;

            }

            return valor;
        }
    }
}
