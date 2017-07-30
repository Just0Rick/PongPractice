using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace GravityTest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D textura;
        Vector2 posicion;
        Vector2 velocidad = Vector2.Zero;
        const float rapidez = 10;
        readonly Vector2 gravedad = new Vector2(0, -9.8f);
        Vector2 LimitesDePantalla;
        bool estaSaltando;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            textura = Content.Load<Texture2D>("playerBullet");
            LimitesDePantalla = new Vector2(
                graphics.GraphicsDevice.Viewport.Width,
                graphics.GraphicsDevice.Viewport.Height
                );
            posicion = new Vector2(0, LimitesDePantalla.Y - 20);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState teclado = Keyboard.GetState();
            float time = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || teclado.IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if(velocidad.X > 0)
                velocidad.X -= 0.05f;
            if (velocidad.X < 0)
                velocidad.X += 0.05f;
            

            if (teclado.IsKeyDown(Keys.Left))
                velocidad.X -= rapidez * time;
            if (teclado.IsKeyDown(Keys.Right))
                velocidad.X += rapidez * time;
            if (teclado.IsKeyDown(Keys.Up) && velocidad.Y > -11 && !estaSaltando)
            {
                velocidad.Y -= 10;
                estaSaltando = true;
            }

            velocidad.Y -= gravedad.Y * time;

            posicion += velocidad;

            if (posicion.X >= LimitesDePantalla.X - 20)
            {
                posicion.X = LimitesDePantalla.X - 20;
                velocidad.X *= -1;
            }

            if (posicion.Y > LimitesDePantalla.Y - 19)
            {
                posicion.Y = LimitesDePantalla.Y - 20;
                velocidad.Y = 0;
                estaSaltando = false;
            }

            if (posicion.X < 0)
            {
                posicion.X = 0;
                velocidad.X *= -1;
            }
            if (posicion.Y < 0)
            {
                posicion.Y = 0;
                velocidad.Y = 0;
            }

            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp);

            spriteBatch.Draw(
                textura, 
                new Rectangle(
                    (int)posicion.X, (int)posicion.Y, 20, 20
                ),
                Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
