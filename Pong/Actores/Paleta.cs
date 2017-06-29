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

    public class Paleta : ActorBase
    {
        private const float rapidez = 5;

        private PlayerPaleta player;

        public Paleta(Texture2D textura, PlayerPaleta player)
            : base(textura)
        {
            Vector2 centro = Coordenadas.CentroDeVentana;
            if (player == PlayerPaleta.PlayerOne)
            {
                posicionInicial = new Vector2(50 - (textura.Width / 2f), centro.Y - (textura.Height / 2f));
            }
            else
            {
                float offset = 50 + (textura.Width / 2f);
                posicionInicial = new Vector2(Coordenadas.LimitesDeVentana.X - offset,
                    centro.Y - (textura.Height / 2f));
            }
            posicionActual = posicionInicial;
            size = new Rectangle((int)posicionInicial.X, (int)posicionInicial.Y, textura.Width, textura.Height);
            this.player = player;
        }

        public Paleta(Texture2D textura, PlayerPaleta player, Point size)
            : this(textura, player)
        {
            Vector2 centro = Coordenadas.CentroDeVentana;
            if (player == PlayerPaleta.PlayerOne)
            {
                posicionInicial = new Vector2(50 - (size.X / 2f), centro.Y - (size.Y / 2f));
            }
            else
            {
                float offset = 50 + (size.X / 2f);
                posicionInicial = new Vector2(Coordenadas.LimitesDeVentana.X - offset, centro.Y - (size.Y /2f));
            }
            posicionActual = posicionInicial;
            this.size = new Rectangle((int)posicionInicial.X, (int)posicionInicial.Y, size.X, size.Y);
        }

        public override void Update(GameTime gameTime)
        {
            float movimientoP1 = posicionActual.Y + Input.Analoga.Izquierda.Y * rapidez;
            float movimientoP2 = posicionActual.Y + Input.Analoga.Derecha.Y * rapidez;
            if (player == PlayerPaleta.PlayerOne 
                && (movimientoP1 < Coordenadas.LimitesDeVentana.Y - size.Height && movimientoP1 > 0))
            {
                posicionActual.Y = movimientoP1;
            }
            else if(player == PlayerPaleta.PlayerTwo
                && (movimientoP2 < Coordenadas.LimitesDeVentana.Y - size.Height && movimientoP2 > 0))
            {
                posicionActual.Y = movimientoP2;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            size.Y = (int)posicionActual.Y;
            spriteBatch.Draw(textura, size, Color.White);
        }
    }
}
