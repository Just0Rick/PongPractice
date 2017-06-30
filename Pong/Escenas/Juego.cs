using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Pong.Manejadores;
using static Pong.Global.Config;
using static Pong.Global.Coordenadas;
using Pong.Actores;

namespace Pong.Escenas
{
    public class Juego : EscenaBase
    {
        private int puntajeP1, puntajeP2;
        private Vector2 posicionPuntaje1, posicionPuntaje2;
        private SpriteFont tipoDeLetraPuntaje;
        private Vector2 puntajeSize;
        private int puntajeOffset;

        private bool alguienGano;
        private Vector2 alguienGanoPosicion;
        private string ganadorName;
        private Paleta playerOne, playerTwo;
        private string[] coloresPaletaP1 = { "pongPaletaRoja", "pongPaletaVerde", "pongPaletaAzul" };
        private string[] coloresPaletaP2 = { "pongPaletaAmarilla", "pongPaletaRosa", "pongPaletaBlanca" };

        private Pelota pelota;

        private Texture2D fondoTextura;
        private Point fondoSize;
        public override string Nombre { get; protected set; }

        public Juego(Pantallas manejador, SpriteBatch spriteBatch, string Padre) 
            : base(manejador, spriteBatch, Padre)
        {
            Nombre = "Juego";
            puntajeP1 = puntajeP2 = 0;
            InicializarComponentes();
        }

        protected override void InicializarComponentes()
        {
            playerOne = new Paleta(manejador.CargarRecurso<Texture2D>("Texturas/"+coloresPaletaP1[ColoresIndexP1]),
                PlayerPaleta.PlayerOne, new Point(20, 100));
            playerTwo = new Paleta(manejador.CargarRecurso<Texture2D>("Texturas/" + coloresPaletaP2[ColoresIndexP2]),
                PlayerPaleta.PlayerTwo, new Point(20, 100));

            tipoDeLetraPuntaje = manejador.CargarRecurso<SpriteFont>("Fonts/fontPuntaje");
            puntajeSize = tipoDeLetraPuntaje.MeasureString("998");
            puntajeOffset = 100;
            posicionPuntaje1 = new Vector2(puntajeOffset, 30);
            int p2offset = puntajeOffset + (int)puntajeSize.X;
            posicionPuntaje2 = new Vector2(LimitesDeVentana.X - p2offset, 30);


            Vector2 medidasGano = tipoDeLetraPuntaje.MeasureString("Player Xxx gana!");
            alguienGanoPosicion = new Vector2(CentroDeVentana.X - (medidasGano.X / 2),
                CentroDeVentana.Y - (medidasGano.Y / 2));

            pelota = new Pelota(manejador.CargarRecurso<Texture2D>("Texturas/pongPelota"), new Point(30, 30));

            fondoTextura = manejador.CargarRecurso<Texture2D>("Texturas/pongBackground2");
            fondoSize = new Point((int)LimitesDeVentana.X, (int)LimitesDeVentana.Y);
        }

        public override void Update(GameTime gameTime)
        {
            if (Input.Boton.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                manejador.CambiarANuevaEscena<MenuPrincipal>(false);
            }

            if (alguienGano)
                return;
            playerOne.Update(gameTime);
            playerTwo.Update(gameTime);
            pelota.Update(gameTime);

            Vector2 pelotaLimites = new Vector2(pelota.CajaDeLimites.X + pelota.CajaDeLimites.Width,
                pelota.CajaDeLimites.Y + pelota.CajaDeLimites.Height);

            if (pelotaLimites.Y > LimitesDeVentana.Y || pelota.CajaDeLimites.Y < 0)
                pelota.NotificarColision(TipoDeColision.Pared);

            if (pelota.CajaDeLimites.X > LimitesDeVentana.X)
            {
                pelota.NotificarColision(TipoDeColision.Gol);
                puntajeP1++;
                if(puntajeP1 >= CantidadParaGanar)
                {
                    alguienGano = true;
                    ganadorName = "Player uno";
                }
            }

            if(pelotaLimites.X < 0)
            {
                pelota.NotificarColision(TipoDeColision.Gol);
                puntajeP2++;
                if(puntajeP2 >= CantidadParaGanar)
                {
                    alguienGano = true;
                    ganadorName = "Player dos";
                }
            }

            if (playerOne.CajaDeLimites.Intersects(pelota.CajaDeLimites)
                || playerTwo.CajaDeLimites.Intersects(pelota.CajaDeLimites))
                pelota.NotificarColision(TipoDeColision.Paleta);
            else
                pelota.NotificarColision(TipoDeColision.Ninguno);

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(fondoTextura, new Rectangle(0, 0, fondoSize.X, fondoSize.Y), Color.White);
            if (!alguienGano)
            {
                pelota.Draw(spriteBatch);
                playerOne.Draw(spriteBatch);
                playerTwo.Draw(spriteBatch);
                spriteBatch.DrawString(tipoDeLetraPuntaje, puntajeP1.ToString(), posicionPuntaje1, Color.White);
                spriteBatch.DrawString(tipoDeLetraPuntaje, puntajeP2.ToString(), posicionPuntaje2, Color.White);
            }
            else
            {
                spriteBatch.DrawString(tipoDeLetraPuntaje, ganadorName + " gana!", alguienGanoPosicion, Color.Bisque);
            }

            spriteBatch.End();
        }
        
    }
}
