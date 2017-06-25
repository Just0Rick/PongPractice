namespace Pong.Global
{
    public static class Config
    {
        public static int ColoresIndex { get; set; }
        public static int CantidadParaGanar { get; set; }

        static Config()
        {
            ColoresIndex = 0;
            CantidadParaGanar = 10;
        }
    }
}
