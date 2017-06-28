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

        static Config()
        {
            ColoresIndexP1 = 0;
            ColoresIndexP2 = 0;
            CantidadParaGanar = 10;
        }

        public Config(int co1, int co2, int ca)
        {
            InstanceColoresIndexP1 = co1;
            InstanceColoresIndexP2 = co2;
            InstanceCantidadParaGanar = ca;
        }

        public static Config ObtenerObjeto()
        {
            return new Config(ColoresIndexP1, ColoresIndexP2, CantidadParaGanar);
        }

        public static void SetValues(Config valores)
        {
            ColoresIndexP1 = valores.InstanceColoresIndexP1;
            ColoresIndexP2 = valores.InstanceColoresIndexP2;
            CantidadParaGanar = valores.InstanceCantidadParaGanar;
        }
    }
}
