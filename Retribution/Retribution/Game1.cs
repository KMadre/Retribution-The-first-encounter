using Retribution.ScriptReader;
using Retribution.PlayerRelated;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Retribution.Projectiles;
using Retribution.StageHandlerSpace.EnemyHandlerSpace;
using Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyFactories;
using Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyTypes;
using Retribution.StageHandlerSpace;

/// <summary>
/// Programmers: Kieran Madre
/// Summary: Create a Bullethell game with good software architecture and design
/// Date Created: 1/30/2024
/// </summary>

namespace Retribution
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public Player player;
        public ProjectileHandler ProjectileHandler;
        public StageHandler stageHandler;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferHeight = Globals.SCREEN_HEIGHT;
            _graphics.PreferredBackBufferWidth = Globals.SCREEN_WIDTH;
            Content.RootDirectory = "Content";
            Globals.Content = Content;
            IsMouseVisible = true; // leave true
        }


        /// <summary>
        /// Summary: Add game initialization logic in here
        /// </summary>
        protected override void Initialize()
        {
            this.player = new Player();
            this.ProjectileHandler = new ProjectileHandler();
            this.stageHandler = new StageHandler();

            Globals.UnPauseGame();

            base.Initialize();
        }

        /// <summary>
        /// Summary: Use this.Content to load your game content here
        /// </summary>
        protected override void LoadContent()
        {
            Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);

            player.LoadTexture(); // load player texture
            ProjectileHandler.LoadTextures();
            stageHandler.LoadTextures();
        }

        /// <summary>
        /// Add your update logic here (every frame = one update)
        /// </summary>
        /// <param name="gameTime">This parameter handles the time that happened in game, and makes Frames seperate from game speed</param>
        protected override void Update(GameTime gameTime)
        {
            Globals.Update(gameTime);
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.P))
            {
                Globals.PauseGame();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.O))
            {
                Globals.UnPauseGame();
            }
            player.InputScript(player, ProjectileHandler); // player
            stageHandler.Update();
            ProjectileHandler.Path();
            ProjectileHandler.Update(stageHandler.enemyHandlerList[0], player);

            base.Update(gameTime);
        }

        /// <summary>
        /// Add your drawing code here. Rendering
        /// </summary>
        /// <param name="gameTime">This parameter handles the time that happened in game, and makes Frames seperate from game speed</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);//Clear the screen
            Globals.SpriteBatch.Begin();// begin sprite drawing

            // Draw Player
            Globals.SpriteBatch.Draw(player.Texture, player.Position, Color.White);

            ProjectileHandler.Draw();
            stageHandler.Draw();

            Globals.SpriteBatch.End();// stop sprite drawing
            base.Draw(gameTime);
        }
    }
}