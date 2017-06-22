using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Pong.Manejadores;
using Pong.Global;
using System;

namespace Pong.Escenas
{
    public class MenuPrincipal : EscenaBase
    {
        private SpriteFont opcionesTipoDeLetra;
        private Vector2 opcionesPosicionA, opcionesPosicionB, opcionesPosicionC;
        private SpriteFont tituloTipoDeLetra;
        private Vector2 tituloPosicion;
        private string[] cadenas = new string[] { "Iniciar","Opciones","Salir" };


        public override string Nombre { get; protected set; }
        

        public MenuPrincipal(Pantallas manejador, SpriteBatch spriteBatch) : base(manejador, spriteBatch, null)
        {
            Nombre = "MenuPrincipal";
            InicializarComponentes();
        }

        protected override void InicializarComponentes()
        {
            Vector2 centroDePantalla = new Vector2(Coordenadas.LimitesDeVentana.X / 2f,
                Coordenadas.LimitesDeVentana.Y / 2f);
            opcionesTipoDeLetra = manejador.CargarRecurso<SpriteFont>("Fonts/fontMenu");
            Vector2 sizeOpA, sizeOpB, sizeOpC;
            sizeOpA = opcionesTipoDeLetra.MeasureString(cadenas[0]);
            sizeOpB = opcionesTipoDeLetra.MeasureString(cadenas[1]);
            sizeOpC = opcionesTipoDeLetra.MeasureString(cadenas[2]);
            opcionesPosicionA = new Vector2(centroDePantalla.X - (sizeOpA.X/2f),
                centroDePantalla.Y - 100);
            opcionesPosicionB = new Vector2(centroDePantalla.X - (sizeOpB.X / 2f),
                opcionesPosicionA.Y + sizeOpA.Y + 20);
            opcionesPosicionC = new Vector2(centroDePantalla.X - (sizeOpC.X / 2f),
                opcionesPosicionB.Y + sizeOpB.Y + 20);
            tituloTipoDeLetra = manejador.CargarRecurso<SpriteFont>("Fonts/fontTitulo");
            Vector2 sizeTitulo = tituloTipoDeLetra.MeasureString("PONG");
            tituloPosicion = new Vector2(centroDePantalla.X - (sizeTitulo.X / 2f),
                20);
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(tituloTipoDeLetra, "PONG", tituloPosicion, Color.White);
            spriteBatch.DrawString(opcionesTipoDeLetra, cadenas[0], opcionesPosicionA, Color.White);
            spriteBatch.DrawString(opcionesTipoDeLetra, cadenas[1], opcionesPosicionB, Color.White);
            spriteBatch.DrawString(opcionesTipoDeLetra, cadenas[2], opcionesPosicionC, Color.White);

            spriteBatch.End();
        }

    }
}
