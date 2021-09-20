using System.ComponentModel;

namespace Cartola.Helper.Enumeradores
{
    public enum TipoPosicao
    {
        [Description("Gol")]
        Goleiro = 1,
        [Description("Lat")]
        Lateral,
        [Description("Zag")]
        Zagueiro,
        [Description("Mei")]
        MeioCampo,
        [Description("Ata")]
        Atacante,
        [Description("Tec")]
        Tecnico
    }
}
