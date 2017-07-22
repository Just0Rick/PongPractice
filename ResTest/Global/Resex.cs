using Microsoft.Xna.Framework;

namespace ResTest.Global
{
    public static class Resex
    {
        private static int PantallaAncho;
        private static int PantallaAlto;

        private static float VirtualAncho;
        private static float VirtualAlto;

        private static float ratioX;
        private static float ratioY;

        private static void CalcularRatio()
        {
            ratioY = PantallaAlto / VirtualAlto;
            ratioX = PantallaAncho / VirtualAncho;
        }

        public static void Inicializar(Game1 game)
        {
            PantallaAlto = game.GraphicsDevice.Viewport.Height;
            PantallaAncho = game.GraphicsDevice.Viewport.Width;

            VirtualAlto = 720;
            VirtualAncho = 1240;
            CalcularRatio();
        }

        public static void CambiarResolucionVirtual(Game1 game, Vector2 nuevaRes)
        {
            Inicializar(game);
            VirtualAlto = nuevaRes.Y;
            VirtualAncho = nuevaRes.X;
            CalcularRatio();
        }

        public static Vector2 TraducirCoordenadas(Vector2 coordenadas)
        {
            Vector2 nuevasCoordenadas = new Vector2(coordenadas.X * ratioX, coordenadas.Y * ratioY);
            return nuevasCoordenadas;
        }
    }
}
