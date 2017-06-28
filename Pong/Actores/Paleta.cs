using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Pong.Global;
using Pong.Manejadores;

namespace Pong.Actores
{

    public enum PlayerPaleta
    {
        PlayerOne,
        PlayerTwo,
    }

    public class Paleta
    {

        private Texture2D textura;
        private Vector2 posicionInicial;
        private Vector2 posicionActual;
        private const float rapidez = 5;
        private Rectangle size;

        private PlayerPaleta player;
        
        public Vector2 PosicionActual
        {
            get
            {
                return posicionActual;
            }

            set
            {
                Vector2 pantalla = Coordenadas.LimitesDeVentana;
                if (value.X > pantalla.X || value.X < 0 || value.Y > pantalla.Y || value.Y < 0)
                    return;
                posicionActual = value;
            }
        }

        public Rectangle CajaDeLimites
        {
            get
            {
                return new Rectangle((int)posicionActual.X, (int)posicionActual.Y, textura.Width, textura.Height);
            }
        }

        public Paleta(Texture2D textura, PlayerPaleta player, Vector2 posicionInicial)
        {
            this.textura = textura;
            posicionActual = this.posicionInicial = posicionInicial;
            size = new Rectangle((int)posicionInicial.X, (int)posicionInicial.Y, textura.Width, textura.Height);
            this.player = player;
        }

        public void Update()
        {
            if (player == PlayerPaleta.PlayerOne)
                posicionActual.Y += Input.Analoga.Izquierda.Y * rapidez;
            else
                posicionActual.Y += Input.Analoga.Derecha.Y * rapidez;
        }

        public Paleta(Texture2D textura, PlayerPaleta player, Rectangle size)
            : this(textura, player, new Vector2(size.X, size.Y))
        {
            this.size = size;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            size.Y = (int)posicionActual.Y;
            spriteBatch.Draw(textura, size, Color.White);
        }
    }
}
