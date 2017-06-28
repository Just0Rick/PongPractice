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
        private Vector2 opcionesSizeA, opcionesSizeB, opcionesSizeC;
        private Color opcionesColorA, opcionesColorB, opcionesColorC;
        private Vector2 opcionesPosicionA, opcionesPosicionB, opcionesPosicionC;
        private Vector2 configSizeA, configSizeB, configSizeC;
        private Vector2 configPosicionA, configPosicionB, configPosicionC;
        private Vector2 notaSize;
        private Vector2 notaPosicion;
        private string notaCadena = "Para guardar los cambios, presione \"Menu\". Para cancelar, presione \"Back\"";
        private string[] opcionesCadenas = { "Cantidad para ganar: ", "Color de paleta P1: ", "Color de paleta P2: " };
        private string[] cadenasDePaletaP1 = { "Rojo", "Verde", "Azul" };
        private string[] cadenasDePaletaP2 = { "Amarillo", "Rosa", "Blanco" };
        private Color[] coloresDePaletaP1 = { Color.Red, Color.Green, Color.Blue };
        private Color[] coloresDePaletaP2 = { Color.Yellow, Color.Pink, Color.White };
        private cirint coloresP1Index, coloresP2Index;
        private cirint seleccionIndex;
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
            seleccionIndex = 0;
            coloresP1Index = Config.ColoresIndexP1;
            coloresP2Index = Config.ColoresIndexP2;
            cantidadParaGanar = Config.CantidadParaGanar;
            inputAnterior = 0;
            seleccionColor = Color.Magenta;
            InicializarComponentes();
            
        }

        protected override void InicializarComponentes()
        {
            opcionesColorA = opcionesColorB = opcionesColorC = Color.White;

            opcionesTipoDeLetra = manejador.CargarRecurso<SpriteFont>("Fonts/fontMenu");
            configTipoDeLetra = manejador.CargarRecurso<SpriteFont>("Fonts/fontTitulo");
            notaTipoDeLetra = manejador.CargarRecurso<SpriteFont>("Fonts/fontNota");

            Vector2 limites = Coordenadas.LimitesDeVentana;
            Vector2 centro = new Vector2(limites.X / 2f, limites.Y / 2f);

            opcionesSizeA = opcionesTipoDeLetra.MeasureString(opcionesCadenas[0]);
            opcionesSizeB = opcionesTipoDeLetra.MeasureString(opcionesCadenas[1]);
            opcionesSizeC = opcionesTipoDeLetra.MeasureString(opcionesCadenas[2]);
            configSizeA = configTipoDeLetra.MeasureString(cadenasDePaletaP1[1]);
            configSizeB = configTipoDeLetra.MeasureString(999.ToString());
            configSizeC = configTipoDeLetra.MeasureString(cadenasDePaletaP2[0]);
            notaSize = notaTipoDeLetra.MeasureString(notaCadena);

            opcionesPosicionA = new Vector2(40, 40);
            opcionesPosicionB = new Vector2(opcionesPosicionA.X, opcionesPosicionA.Y + opcionesSizeA.Y + 30);
            opcionesPosicionC = new Vector2(opcionesPosicionA.X, opcionesPosicionB.Y + opcionesSizeB.Y + 30);

            configPosicionA = new Vector2(opcionesPosicionA.X + opcionesSizeA.X + 20, opcionesPosicionA.Y - 10);
            configPosicionB = new Vector2(opcionesPosicionB.X + opcionesSizeB.X + 20, opcionesPosicionB.Y - 10);
            configPosicionC = new Vector2(opcionesPosicionC.X + opcionesSizeC.X + 20, opcionesPosicionC.Y - 10);

            notaPosicion = new Vector2(limites.X - notaSize.X - 20, limites.Y - notaSize.Y - 20);
        }

        protected bool EstaDentroDelRangoParaGanar(int x)
        {
            return (x >= 5 && x <= 999);
        }

        public override void Update(GameTime gameTime)
        {
            if (Input.Boton.Back == ButtonState.Pressed || Input.Boton.B == ButtonState.Pressed)
            {
                manejador.CambiarAEscenaCargada(Padre, false);
            }
            else if (Input.Boton.Menu == ButtonState.Pressed)
            {
                Config.CantidadParaGanar = cantidadParaGanar;
                Config.ColoresIndexP1 = coloresP1Index;
                Config.ColoresIndexP2 = coloresP2Index;
                manejador.CambiarAEscenaCargada(Padre, false);
            }

            if ( Input.Analoga.Izquierda.Y > 0.5 && inputAnteriorY < 0.5 && inputAnteriorY >= 0 )
            {
                inputAnteriorY = Input.Analoga.Izquierda.Y;
                seleccionIndex++;
            }
            else if (Input.Analoga.Izquierda.Y < -0.5 && inputAnteriorY > -0.5 && inputAnteriorY <= 0)
            {
                inputAnteriorY = Input.Analoga.Izquierda.Y;
                seleccionIndex--;
            }
            else
            {
                inputAnteriorY = Input.Analoga.Izquierda.Y;
            }

            switch(seleccionIndex)
            {
                case 0:
                    opcionesColorA = seleccionColor;
                    opcionesColorB = Color.White;
                    opcionesColorC = Color.White;
                    break;
                case 1:
                    opcionesColorA = Color.White;
                    opcionesColorB = seleccionColor;
                    opcionesColorC = Color.White;
                    break;
                case 2:
                    opcionesColorA = Color.White;
                    opcionesColorB = Color.White;
                    opcionesColorC = seleccionColor;
                    break;
            }

            if (Input.Analoga.Izquierda.X > 0.5 && inputAnterior < 0.5 && inputAnterior >= 0)
            {
                inputAnterior = Input.Analoga.Izquierda.X;
                if (seleccionIndex == 1)
                {
                    coloresP1Index++;
                }
                else if(seleccionIndex == 2)
                {
                    coloresP2Index++;
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
                if(seleccionIndex == 1)
                {
                    coloresP1Index--;
                }
                else if(seleccionIndex == 2)
                {
                    coloresP2Index--;
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
            spriteBatch.DrawString(opcionesTipoDeLetra, opcionesCadenas[2], opcionesPosicionC, opcionesColorC);

            spriteBatch.DrawString(configTipoDeLetra, cantidadParaGanar.ToString(), configPosicionA, Color.White);
            spriteBatch.DrawString(configTipoDeLetra, cadenasDePaletaP1[coloresP1Index], configPosicionB, coloresDePaletaP1[coloresP1Index]);
            spriteBatch.DrawString(configTipoDeLetra, cadenasDePaletaP2[coloresP2Index], configPosicionC, coloresDePaletaP2[coloresP2Index]);

            spriteBatch.DrawString(notaTipoDeLetra, notaCadena, notaPosicion, Color.White);

            spriteBatch.End();
        }
    }
}
