using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Pong.Manejadores;
using static Pong.Global.Config;
using Pong.Actores;

namespace Pong.Escenas
{
    public class Juego : EscenaBase
    {
        private Paleta playerOne, playerTwo;
        private string[] coloresPaletaP1 = { "pongPaletaRoja", "pongPaletaVerde", "pongPaletaAzul" };
        private string[] coloresPaletaP2 = { "pongPaletaAmarilla", "pongPaletaRosa", "pongPaletaBlanca" };
        public override string Nombre { get; protected set; }

        public Juego(Pantallas manejador, SpriteBatch spriteBatch, string Padre) 
            : base(manejador, spriteBatch, Padre)
        {
            Nombre = "Juego";
            InicializarComponentes();
        }

        protected override void InicializarComponentes()
        {
            playerOne = new Paleta(manejador.CargarRecurso<Texture2D>("Texturas/"+coloresPaletaP1[ColoresIndexP1]),
                PlayerPaleta.PlayerOne, new Point(20, 100));
            playerTwo = new Paleta(manejador.CargarRecurso<Texture2D>("Texturas/" + coloresPaletaP2[ColoresIndexP2]),
                PlayerPaleta.PlayerTwo, new Point(20, 100));
        }

        public override void Update(GameTime gameTime)
        {
            playerOne.Update();
            playerTwo.Update();
            if(Input.Boton.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                manejador.CambiarANuevaEscena<MenuPrincipal>(false);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            playerOne.Draw(spriteBatch);
            playerTwo.Draw(spriteBatch);

            spriteBatch.End();
        }
        
    }
}
