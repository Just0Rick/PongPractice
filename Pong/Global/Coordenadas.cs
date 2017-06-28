using Microsoft.Xna.Framework;


namespace Pong.Global
{
    public static class Coordenadas
    {
        private static Vector2 limitesDeVentana = new Vector2(800, 600);
        private static Vector2 limitesDePantalla = new Vector2(1366, 768);
        private static Vector2 centroDeVentana = new Vector2(400, 300);
        private static Vector2 centroDePantalla = new Vector2(683, 384);

        public static void InicializarDatos(PongGame contexto)
        {
            limitesDePantalla.X = contexto.GraphicsDevice.DisplayMode.Width;
            limitesDePantalla.Y = contexto.GraphicsDevice.DisplayMode.Height;

            limitesDeVentana.X = contexto.Window.ClientBounds.Width;
            limitesDeVentana.Y = contexto.Window.ClientBounds.Height;

            centroDeVentana.X = limitesDeVentana.X / 2;
            centroDeVentana.Y = limitesDeVentana.Y / 2;

            centroDePantalla.X = limitesDePantalla.X / 2;
            centroDePantalla.Y = limitesDePantalla.Y / 2;
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

        public static Vector2 CentroDeVentana
        {
            get
            {
                return centroDeVentana;
            }
        }

        public static Vector2 CentroDePantalla
        {
            get
            {
                return centroDePantalla;
            }
        }
    }
}
