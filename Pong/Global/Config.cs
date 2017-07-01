using System;
using System.Runtime.Serialization;

namespace Pong.Global
{
    [Serializable()]
    public class Config
    {
        public static int ColoresIndexP1 { get; set; }
        public static int ColoresIndexP2 { get; set; }
        public int InstanceColoresIndexP1 { get; private set; }
        public int InstanceColoresIndexP2 { get; private set; }
        public static int CantidadParaGanar { get; set; }
        public int InstanceCantidadParaGanar { get; private set; }
        public static int MultiplicadorDeRapidez { get; set; }
        public int InstanceMultiplicadorDeRapidez { get; private set; }

        static Config()
        {
            ColoresIndexP1 = 0;
            ColoresIndexP2 = 0;
            CantidadParaGanar = 10;
            MultiplicadorDeRapidez = 1;
        }

        public Config(int co1, int co2, int ca, int ra)
        {
            InstanceColoresIndexP1 = co1;
            InstanceColoresIndexP2 = co2;
            InstanceCantidadParaGanar = ca;
            InstanceMultiplicadorDeRapidez = ra;
        }

        public static Config ObtenerObjeto()
        {
            return new Config(ColoresIndexP1, ColoresIndexP2, CantidadParaGanar, MultiplicadorDeRapidez);
        }

        public static void SetValues(Config valores)
        {
            ColoresIndexP1 = valores.InstanceColoresIndexP1;
            ColoresIndexP2 = valores.InstanceColoresIndexP2;
            CantidadParaGanar = valores.InstanceCantidadParaGanar;
        }
    }
}
