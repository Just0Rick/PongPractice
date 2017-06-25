using System;
using System.Runtime.Serialization;

namespace Pong.Global
{
    [Serializable()]
    public class Config
    {
        public static int ColoresIndex { get; set; }
        public int InstanceColoresIndex { get; private set; }
        public static int CantidadParaGanar { get; set; }
        public int InstanceCantidadParaGanar { get; private set; }

        static Config()
        {
            ColoresIndex = 0;
            CantidadParaGanar = 10;
        }

        public Config(int co, int ca)
        {
            InstanceColoresIndex = co;
            InstanceCantidadParaGanar = ca;
        }

        public static Config ObtenerObjeto()
        {
            return new Config(ColoresIndex, CantidadParaGanar);
        }

        public static void SetValues(Config valores)
        {
            ColoresIndex = valores.InstanceColoresIndex;
            CantidadParaGanar = valores.InstanceCantidadParaGanar;
        }
    }
}
