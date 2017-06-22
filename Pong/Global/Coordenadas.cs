using Microsoft.Xna.Framework;


namespace Pong.Global
{
    public static class Coordenadas
    {
        private static Vector2 limitesDeVentana = new Vector2(800, 600);
        private static Vector2 limitesDePantalla = new Vector2(1366, 768);

        public static void InicializarDatos(PongGame contexto)
        {
            limitesDePantalla.X = contexto.GraphicsDevice.DisplayMode.Width;
            limitesDePantalla.Y = contexto.GraphicsDevice.DisplayMode.Height;

            limitesDeVentana.X = contexto.Window.ClientBounds.X;
            limitesDeVentana.Y = contexto.Window.ClientBounds.Y;
        }

        public static Vector2 LimitesDeVentana
        {
            get
            {
                return limitesDeVentana;
            }
        }

        public static Vector2 LimitesDePantalla
        {
            get
            {
                return limitesDePantalla;
            }
        }
    }
}
