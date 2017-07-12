using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Text;

namespace AATest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        string profileSupportReach, profileSupportHiDef, currentProfile;
        Vector2 profileSupportSize;
        StringBuilder adaptadores;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            adaptadores = new StringBuilder();
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

            font = Content.Load<SpriteFont>("File");
            GraphicsAdapter adaptador = graphics.GraphicsDevice.Adapter;
            SurfaceFormat formato = adaptador.CurrentDisplayMode.Format;
            profileSupportReach = "El profile Reach esta soportado por esta tarjeta: ";
            profileSupportHiDef = "El profile HiDef esta soportado por esta tarjeta: ";
            currentProfile = "El profile activo actualmente es: " + GraphicsDevice.GraphicsProfile;

            profileSupportSize = font.MeasureString(profileSupportReach);
            
            adaptadores.Append("Tarjetas encontradas: \n");
            foreach(GraphicsAdapter another in GraphicsAdapter.Adapters)
            {
                adaptadores.Append("* " + another.Description + "\n");
            }

            if(adaptador.IsProfileSupported(GraphicsProfile.Reach))
            {
                profileSupportReach += "Si";
            }
            else
            {
                profileSupportReach += "No";
            }

            if(adaptador.IsProfileSupported(GraphicsProfile.HiDef))
            {
                profileSupportHiDef += "Si";
            }
            else
            {
                profileSupportHiDef += "No";
            }
            // TODO: use this.Content to load your game content here
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            Vector2 pos2 = new Vector2(0, profileSupportSize.Y + 10);
            Vector2 pos3 = new Vector2(0, pos2.Y + profileSupportSize.Y + 10);
            Vector2 pos4 = new Vector2(0, pos3.Y + profileSupportSize.Y + 10);
            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.DrawString(font, profileSupportReach, Vector2.Zero, Color.White);
            spriteBatch.DrawString(font, profileSupportHiDef, pos2, Color.White);
            spriteBatch.DrawString(font, currentProfile, pos3, Color.White);
            spriteBatch.DrawString(font, adaptadores.ToString(), pos4, Color.White);

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
