using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Pong.Global;

namespace Pong.Actores
{
    public abstract class ActorBase
    {
        protected Texture2D textura;
        protected Vector2 posicionInicial;
        protected Vector2 posicionActual;
        protected Rectangle size;

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
                    posicionActual = Vector2.Zero;
                else
                    posicionActual = value;
            }
        }

        public Rectangle CajaDeLimites
        {
            get
            {
                return size;
            }
        }

        public ActorBase(Texture2D textura)
        {
            posicionInicial = posicionActual = Vector2.Zero;
            this.textura = textura;
        }

        public ActorBase(Texture2D textura, Point size) : this(textura)
        {
            this.size = new Rectangle(0, 0, size.X, size.Y);
        }

        public ActorBase(Texture2D textura, Point size, Vector2 posicionInicial)
            : this(textura, size)
        {
            this.size.X = (int)posicionInicial.X;
            this.size.Y = (int)posicionInicial.Y;
            posicionActual = posicionInicial;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
