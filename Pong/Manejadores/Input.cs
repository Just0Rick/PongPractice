using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pong.Manejadores
{
    public struct TodosLosBotones
    {
        private const Keys kA_Boton = Keys.K;
        private const Keys kB_Boton = Keys.L;
        private const Keys kY_Boton = Keys.I;
        private const Keys kX_Boton = Keys.J;

        private const Keys kLB_Boton = Keys.Q;
        private const Keys kRB_Boton = Keys.E;

        private const Keys kBack_Boton = Keys.F1;
        private const Keys kMenu_Boton = Keys.Escape;

        private const Keys kLS_Boton = Keys.V;
        private const Keys kRS_Boton = Keys.B;

        private ButtonState ObtenerEstadoBoton(ButtonState estadoControl, Keys tecla)
        {
            if(GamePad.GetState(PlayerIndex.One).IsConnected)
            {
                return estadoControl;
            }

            if (Keyboard.GetState().IsKeyDown(tecla))
            {
                return ButtonState.Pressed;
            }

            return ButtonState.Released;
        }

        public ButtonState A
        {
            get
            {
                return ObtenerEstadoBoton(GamePad.GetState(PlayerIndex.One).Buttons.A, kA_Boton);
            }
        }

        public ButtonState B
        {
            get
            {
                return ObtenerEstadoBoton(GamePad.GetState(PlayerIndex.One).Buttons.B, kB_Boton);
            }
        }

        public ButtonState Y
        {
            get
            {
                return ObtenerEstadoBoton(GamePad.GetState(PlayerIndex.One).Buttons.Y, kY_Boton);
            }
        }

        public ButtonState X
        {
            get
            {
                return ObtenerEstadoBoton(GamePad.GetState(PlayerIndex.One).Buttons.X, kX_Boton);
            }
        }

        public ButtonState LB
        {
            get
            {
                return ObtenerEstadoBoton(GamePad.GetState(PlayerIndex.One).Buttons.LeftShoulder, kLB_Boton);
            }
        }

        public ButtonState RB
        {
            get
            {
                return ObtenerEstadoBoton(GamePad.GetState(PlayerIndex.One).Buttons.RightShoulder, kRB_Boton);
            }
        }

        public ButtonState LS
        {
            get
            {
                return ObtenerEstadoBoton(GamePad.GetState(PlayerIndex.One).Buttons.LeftStick, kLS_Boton);
            }
        }

        public ButtonState RS
        {
            get
            {
                return ObtenerEstadoBoton(GamePad.GetState(PlayerIndex.One).Buttons.RightStick, kRS_Boton);
            }
        }

        public ButtonState Back
        {
            get
            {
                return ObtenerEstadoBoton(GamePad.GetState(PlayerIndex.One).Buttons.Back, kBack_Boton);
            }
        }

        public ButtonState Menu
        {
            get
            {
                return ObtenerEstadoBoton(GamePad.GetState(PlayerIndex.One).Buttons.Start, kMenu_Boton);
            }
        }
    }

    public struct AmbosGatillos
    {
        private const Keys kLT_Boton = Keys.U;
        private const Keys kRT_Boton = Keys.O;

        private const float presionDefault = 0.75f;

        private float ObtenerEstadoGatillo(float estadoControl, Keys tecla)
        {
            if (GamePad.GetState(PlayerIndex.One).IsConnected)
                return estadoControl;

            if (Keyboard.GetState().IsKeyDown(tecla))
                return presionDefault;

            return 0;
        }

        public float LT
        {
            get
            {
                return ObtenerEstadoGatillo(GamePad.GetState(PlayerIndex.One).Triggers.Left, kLT_Boton);
            }
        }

        public float RT
        {
            get
            {
                return ObtenerEstadoGatillo(GamePad.GetState(PlayerIndex.One).Triggers.Right, kRT_Boton);
            }
        }
    }

    public struct AmbasPalancas
    {
        private const Keys kIzqAbajo = Keys.S;
        private const Keys kIzqDerecha = Keys.D;
        private const Keys kIzqArriba = Keys.W;
        private const Keys kIzqIzquierda = Keys.A;

        private const Keys kDerAbajo = Keys.Down;
        private const Keys kDerDerecha = Keys.Right;
        private const Keys kDerArriba = Keys.Up;
        private const Keys kDerIzquierda = Keys.Left;

        private const float presionDefault = 0.75f;

        private Vector2 ObtenerEstadoPalanca(Vector2 estadoControl, Keys abajo, Keys derecha, Keys arriba, Keys izquierda)
        {
            Vector2 retorno = Vector2.Zero;
            if (GamePad.GetState(PlayerIndex.One).IsConnected)
            {
                retorno.X += estadoControl.X;
                retorno.Y -= estadoControl.Y;
            }
            else
            {
                KeyboardState teclado = Keyboard.GetState();

                if (teclado.IsKeyDown(abajo))
                    retorno.Y += presionDefault;
                if (teclado.IsKeyDown(derecha))
                    retorno.X += presionDefault;
                if (teclado.IsKeyDown(arriba))
                    retorno.Y -= presionDefault;
                if (teclado.IsKeyDown(izquierda))
                    retorno.X -= presionDefault;
            }

            if (retorno.X > 0)
                retorno.X = 1;
            else if (retorno.X < 0)
                retorno.X = -1;

            if (retorno.Y > 0)
                retorno.Y = 1;
            else if (retorno.Y < 0)
                retorno.Y = -1;
            return retorno;
        }

        public Vector2 Izquierda
        {
            get
            {
                return ObtenerEstadoPalanca(GamePad.GetState(PlayerIndex.One).ThumbSticks.Left,
                    kIzqAbajo, kIzqDerecha, kIzqArriba, kIzqIzquierda);
            }
        }

        public Vector2 Derecha
        {
            get
            {
                return ObtenerEstadoPalanca(GamePad.GetState(PlayerIndex.One).ThumbSticks.Right,
                    kDerAbajo, kDerDerecha, kDerArriba, kDerIzquierda);
            }
        }
    }

    public static class Input
    {
        public static TodosLosBotones Boton = new TodosLosBotones();
        public static AmbasPalancas Analoga = new AmbasPalancas();
        public static AmbosGatillos Gatillo = new AmbosGatillos();
    }
}
