using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Pong.Manejadores;

namespace Pong.Escenas
{
    public abstract class EscenaBase
    {
        public abstract string Nombre { get; protected set; }
        public string Padre { get; protected set; }

        protected Pantallas manejador;
        protected SpriteBatch spriteBatch;

        public EscenaBase(Pantallas manejador, SpriteBatch spriteBatch, string padre = null)
        {
            this.manejador = manejador;
            this.spriteBatch = spriteBatch;
            Padre = padre;
        }

        protected abstract void InicializarComponentes();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }
}
