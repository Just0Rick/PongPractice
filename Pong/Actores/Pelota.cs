using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Pong.Global;

namespace Pong.Actores
{
    public enum TipoDeColision
    {
        Pared,
        Paleta,
        Gol,
        Ninguno
    }

    public class Pelota : ActorBase
    {
        private Random rand;
        private TipoDeColision ultimaNotificacion;
        private const float rapidez = 7;
        private Vector2 velocidad;

        public Pelota(Texture2D textura, Point size)
            : base(textura, size)
        {
            rand = new Random(DateTime.Now.Second);
            posicionActual = posicionInicial = new Vector2(Coordenadas.CentroDeVentana.X, Coordenadas.CentroDeVentana.Y);
            this.size = new Rectangle((int)posicionInicial.X, (int)posicionInicial.Y,
                size.X, size.Y);
            ultimaNotificacion = TipoDeColision.Ninguno;
            DecidirDireccion();
        }

        public override void Update(GameTime gameTime)
        {
            posicionActual += velocidad;
            size.X = (int)posicionActual.X;
            size.Y = (int)posicionActual.Y;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, size, Color.White);
        }

        public void NotificarColision(TipoDeColision sender)
        {
            if (ultimaNotificacion == sender)
                return;

            switch(sender)
            {
                case TipoDeColision.Pared:
                    velocidad.Y *= -1;
                    ultimaNotificacion = TipoDeColision.Pared;
                    break;
                case TipoDeColision.Paleta:
                    velocidad.X *= -1;
                    float x = rand.Next(0, 100) / 50f;
                    if(velocidad.Y > 0)
                    {
                        if(velocidad.Y - x > 0)
                        {
                            velocidad.Y -= x;
                        }
                        else
                        {
                            velocidad.Y += x;
                        }
                    }
                    else
                    {
                        if(velocidad.Y + x < 0)
                        {
                            velocidad.Y += x;
                        }
                        else
                        {
                            velocidad.Y -= x;
                        }
                    }
                    ultimaNotificacion = TipoDeColision.Paleta;
                    break;
                case TipoDeColision.Gol:
                    posicionActual = posicionInicial;
                    DecidirDireccion();
                    ultimaNotificacion = TipoDeColision.Gol;
                    break;
                case TipoDeColision.Ninguno:
                    ultimaNotificacion = TipoDeColision.Ninguno;
                    break;
            }
        }

        private void DecidirDireccion()
        {
            int resultX = rand.Next(0, 2);
            float resultY = rand.Next(0, 101) / 100f;
            velocidad = new Vector2(resultX > 0 ? 1 : -1, resultY);
            velocidad *= rapidez;
        }
    }
}
