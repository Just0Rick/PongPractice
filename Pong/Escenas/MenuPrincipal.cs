using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Pong.Manejadores;
using Pong.Global;
using cirint = Pong.Utils.EnteroCircular;

namespace Pong.Escenas
{
    public class MenuPrincipal : EscenaBase
    {
        private SpriteFont opcionesTipoDeLetra;
        private Vector2 opcionesPosicionA, opcionesPosicionB, opcionesPosicionC;
        private Color colorOpcionA, colorOpcionB, colorOpcionC;
        private SpriteFont tituloTipoDeLetra;
        private Vector2 tituloPosicion;
        private string[] cadenas = new string[] { "Iniciar","Opciones","Salir" };
        private Color selectedColor = Color.Magenta;
        private cirint index;
        private float inputAnterior;

        private Texture2D fondoTextura;
        private Point fondoSize;

        public override string Nombre { get; protected set; }
        

        public MenuPrincipal(Pantallas manejador, SpriteBatch spriteBatch, string padre) 
            : base(manejador, spriteBatch, null)
        {
            Nombre = "MenuPrincipal";
            InicializarComponentes();
        }

        protected override void InicializarComponentes()
        {
            fondoTextura = manejador.CargarRecurso<Texture2D>("Texturas/pongMenuBackground");
            fondoSize = new Point((int)Coordenadas.LimitesDeVentana.X, (int)Coordenadas.LimitesDeVentana.Y);

            index = 0;
            colorOpcionA = colorOpcionB = colorOpcionC = Color.White;
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
            if(Input.Analoga.Izquierda.Y > 0.5 && inputAnterior < 0.5 && inputAnterior >= 0)
            {
                inputAnterior = Input.Analoga.Izquierda.Y;
                index++;
            }
            else if(Input.Analoga.Izquierda.Y < -0.5 && inputAnterior > -0.05 && inputAnterior <= 0)
            {
                inputAnterior = Input.Analoga.Izquierda.Y;
                index--;
            }
            else
            {
                inputAnterior = Input.Analoga.Izquierda.Y;
            }

            switch(index)
            {
                case 0:
                    colorOpcionA = selectedColor;
                    colorOpcionB = Color.White;
                    colorOpcionC = Color.White;
                    break;
                case 1:
                    colorOpcionA = Color.White;
                    colorOpcionB = selectedColor;
                    colorOpcionC = Color.White;
                    break;
                case 2:
                    colorOpcionA = Color.White;
                    colorOpcionB = Color.White;
                    colorOpcionC = selectedColor;
                    break;
            }

            if(Input.Boton.A == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                switch(index)
                {
                    case 0:
                        manejador.CambiarANuevaEscena<Juego>(false);
                        break;
                    case 1:
                        manejador.CambiarANuevaEscena<MenuPrincipalOpciones>(true);
                        break;
                    case 2:
                        manejador.ExitGame();
                        break;
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(fondoTextura, new Rectangle(0, 0, fondoSize.X, fondoSize.Y), Color.White);
            spriteBatch.DrawString(tituloTipoDeLetra, "PONG", tituloPosicion, Color.White);
            spriteBatch.DrawString(opcionesTipoDeLetra, cadenas[0], opcionesPosicionA, colorOpcionA);
            spriteBatch.DrawString(opcionesTipoDeLetra, cadenas[1], opcionesPosicionB, colorOpcionB);
            spriteBatch.DrawString(opcionesTipoDeLetra, cadenas[2], opcionesPosicionC, colorOpcionC);

            spriteBatch.End();
        }

    }
}
