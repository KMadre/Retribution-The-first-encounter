using Retribution.ScriptReader;
using Retribution.PlayerRelated;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Retribution.Projectiles;
using Retribution.StageHandler.EnemyHandlerSpace;
using Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyFactories;
using Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyTypes;

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
        private SpriteBatch _spriteBatch;

        public Player player;
        public ProjectileFactory projectileFactory;
        public EnemyHandler enemyHandler;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true; // leave true
        }


        /// <summary>
        /// Summary: Add game initialization logic in here
        /// </summary>
        protected override void Initialize()
        {
            this.player = new Player();
            this.projectileFactory = new ProjectileFactory();
            this.enemyHandler = new EnemyHandler();

            base.Initialize();
        }

        /// <summary>
        /// Summary: Use this.Content to load your game content here
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            player.LoadTexture(Content); // load player texture
            projectileFactory.LoadTexture(Content);
            enemyHandler.LoadTextures(Content);
        }

        /// <summary>
        /// Add your update logic here (every frame = one update)
        /// </summary>
        /// <param name="gameTime">This parameter handles the time that happened in game, and makes Frames seperate from game speed</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.InputScript(player, gameTime, projectileFactory); // player 
            projectileFactory.HandleProjectiles(gameTime);
            enemyHandler.HandlePathing(gameTime);

            var userButton = Keyboard.GetState(); // grab what button is currently being pressed down
            if (userButton.IsKeyDown(Keys.R))
            {
                enemyHandler.enemies.Add(enemyHandler.gruntAFactory.createGrunt());
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Add your drawing code here. Rendering
        /// </summary>
        /// <param name="gameTime">This parameter handles the time that happened in game, and makes Frames seperate from game speed</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);//Clear the screen
            _spriteBatch.Begin();// begin sprite drawing

            // Draw Player
            _spriteBatch.Draw(player.Texture, player.Position, Color.White);

            foreach(Projectile projectile in projectileFactory.ProjectileList)
            {
                _spriteBatch.Draw(projectileFactory.Texture, projectile.Position, Color.White);
            }
            foreach (BaseEnemy enemy in enemyHandler.enemies)
            {
                if(enemy is GruntA)
                {
                    _spriteBatch.Draw(enemyHandler.gruntATexture, enemy.Position, Color.White);
                }
                if(enemy is GruntB)
                {
                    _spriteBatch.Draw(enemyHandler.gruntBTexture, enemy.Position, Color.White);
                }
            }

            _spriteBatch.End();// stop sprite drawing
            base.Draw(gameTime);
        }
    }
}