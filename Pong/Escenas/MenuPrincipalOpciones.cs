using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using Pong.Manejadores;
using Pong.Global;

using cirint = Pong.Utils.EnteroCircular;


namespace Pong.Escenas
{
    public class MenuPrincipalOpciones : EscenaBase
    {
        private SpriteFont opcionesTipoDeLetra;
        private SpriteFont configTipoDeLetra;
        private SpriteFont notaTipoDeLetra;
        private Vector2 opcionesSizeA, opcionesSizeB;
        private Color opcionesColorA, opcionesColorB;
        private Vector2 opcionesPosicionA, opcionesPosicionB;
        private Vector2 configSizeA, configSizeB;
        private Vector2 configPosicionA, configPosicionB;
        private Vector2 notaSize;
        private Vector2 notaPosicion;
        private string notaCadena = "Para guardar los cambios, presione \"Menu\". Para cancelar, presione \"Back\"";
        private string[] opcionesCadenas = { "Cantidad para ganar: ", "Color de paleta: " };
        private string[] cadenasDePaleta = { "Rojo", "Verde", "Azul" };
        private Color[] coloresDePaleta = { Color.Red, Color.Green, Color.Blue };
        private cirint coloresIndex;
        private bool seleccionIndex;
        private Color seleccionColor;
        float inputAnterior, inputAnteriorY;
        int cantidadParaGanar;
        int minCantidadParaGanar = 5;
        int maxCantidadParaGanar = 999;

        public override string Nombre { get; protected set; }
        public MenuPrincipalOpciones(Pantallas manejador, SpriteBatch spriteBatch, string padre)
            : base(manejador, spriteBatch, padre)
        {
            Nombre = "MenuPrincipalOpciones";
            seleccionIndex = false;
            coloresIndex = Config.ColoresIndex;
            cantidadParaGanar = Config.CantidadParaGanar;
            inputAnterior = 0;
            seleccionColor = Color.Magenta;
            InicializarComponentes();
            
        }

        protected override void InicializarComponentes()
        {
            opcionesColorA = opcionesColorB = Color.White;

            opcionesTipoDeLetra = manejador.CargarRecurso<SpriteFont>("Fonts/fontMenu");
            configTipoDeLetra = manejador.CargarRecurso<SpriteFont>("Fonts/fontTitulo");
            notaTipoDeLetra = manejador.CargarRecurso<SpriteFont>("Fonts/fontNota");

            Vector2 limites = Coordenadas.LimitesDeVentana;
            Vector2 centro = new Vector2(limites.X / 2f, limites.Y / 2f);

            opcionesSizeA = opcionesTipoDeLetra.MeasureString(opcionesCadenas[0]);
            opcionesSizeB = opcionesTipoDeLetra.MeasureString(opcionesCadenas[1]);
            configSizeA = configTipoDeLetra.MeasureString(cadenasDePaleta[1]);
            configSizeB = configTipoDeLetra.MeasureString(999.ToString());
            notaSize = notaTipoDeLetra.MeasureString(notaCadena);

            opcionesPosicionA = new Vector2(40, 40);
            opcionesPosicionB = new Vector2(opcionesPosicionA.X, opcionesPosicionB.Y + opcionesSizeA.Y + 100);

            configPosicionA = new Vector2(opcionesPosicionA.X + opcionesSizeA.X + 20, opcionesPosicionA.Y - 10);
            configPosicionB = new Vector2(opcionesPosicionB.X + opcionesSizeB.X + 20, opcionesPosicionB.Y - 10);

            notaPosicion = new Vector2(limites.X - notaSize.X - 20, limites.Y - notaSize.Y - 20);
        }

        protected bool EstaDentroDelRangoParaGanar(int x)
        {
            return (x >= 5 && x <= 999);
        }

        public override void Update(GameTime gameTime)
        {
            if (Input.Boton.Back == ButtonState.Pressed)
            {
                manejador.CambiarAEscenaCargada(Padre, false);
            }
            else if (Input.Boton.Menu == ButtonState.Pressed)
            {
                Config.CantidadParaGanar = cantidadParaGanar;
                Config.ColoresIndex = coloresIndex;
                manejador.CambiarAEscenaCargada(Padre, false);
            }

            if ( (Input.Analoga.Izquierda.Y > 0.5 && inputAnteriorY < 0.5 && inputAnteriorY >= 0)
                || (Input.Analoga.Izquierda.Y < -0.5 && inputAnteriorY > -0.5 && inputAnteriorY <= 0) )
            {
                inputAnteriorY = Input.Analoga.Izquierda.Y;
                seleccionIndex = !seleccionIndex;
            }
            else
            {
                inputAnteriorY = Input.Analoga.Izquierda.Y;
            }

            if (!seleccionIndex)
            {
                opcionesColorA = seleccionColor;
                opcionesColorB = Color.White;
            }
            else
            {
                opcionesColorA = Color.White;
                opcionesColorB = seleccionColor;
            }

            if (Input.Analoga.Izquierda.X > 0.5 && inputAnterior < 0.5 && inputAnterior >= 0)
            {
                inputAnterior = Input.Analoga.Izquierda.X;
                if (seleccionIndex)
                {
                    coloresIndex++;
                }
                else
                {
                    if (EstaDentroDelRangoParaGanar(cantidadParaGanar + 1))
                        cantidadParaGanar++;
                    else
                        cantidadParaGanar = minCantidadParaGanar;
                }
            }
            else if (Input.Analoga.Izquierda.X < -0.5 && inputAnterior > -0.05 && inputAnterior <= 0)
            {
                inputAnterior = Input.Analoga.Izquierda.X;
                if(seleccionIndex)
                {
                    coloresIndex--;
                }
                else
                {
                    if (EstaDentroDelRangoParaGanar(cantidadParaGanar - 1))
                        cantidadParaGanar--;
                    else
                        cantidadParaGanar = maxCantidadParaGanar;
                }
            }
            else
            {
                inputAnterior = Input.Analoga.Izquierda.X;
            }

            
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(opcionesTipoDeLetra, opcionesCadenas[0], opcionesPosicionA, opcionesColorA);
            spriteBatch.DrawString(opcionesTipoDeLetra, opcionesCadenas[1], opcionesPosicionB, opcionesColorB);

            spriteBatch.DrawString(configTipoDeLetra, cantidadParaGanar.ToString(), configPosicionA, Color.White);
            spriteBatch.DrawString(configTipoDeLetra, cadenasDePaleta[coloresIndex], configPosicionB, coloresDePaleta[coloresIndex]);

            spriteBatch.DrawString(notaTipoDeLetra, notaCadena, notaPosicion, Color.White);

            spriteBatch.End();
        }
    }
}
