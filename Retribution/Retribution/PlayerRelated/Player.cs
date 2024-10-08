﻿using Retribution.Projectiles;
using Retribution.ScriptReader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Programmer: Kieran Madre
/// Date: 1/30/2024
/// 
/// Purpose: this class will handle all of the player related features such as movement, Lives, gun stats and attacks
/// </summary>

namespace Retribution.PlayerRelated
{
    public class Player : IUpgradeable
    {
        public static Player instance;
        public int CurrentLives{ get; set; } // Lives updates in live game
        public float CurrentSpeed{ get; set; }  // speed updates in live game
        public int Lives;  // Max Lives that was set
        private float Speed; // Max speed that was set

        public Vector2 Position { get; set; }

        public Rectangle hitbox;

        public string TextureName { get;}
        public Texture2D Texture;
        private PlayerInput input;
        public Gun gun;

        public Player()
        {
            instance = this;
            this.CurrentLives = 0;
            this.CurrentSpeed = 0f;
            this.Lives = 0;
            this.Speed = 0f;
            CenterPlayer();
            this.hitbox = new Rectangle((int)this.Position.X, (int)this.Position.Y, 32, 32);
            this.TextureName = "Textures//Player";
            this.input = new PlayerInput();
            this.gun = new Gun();
            LoadPlayerScript();
            updateLivesFromDifficulty();
        }

        public static Player GetPlayer()
        {
            if (instance == null)
            {
                instance = new Player();
            }
            return instance;
        }

        /// <summary>
        /// Programmer: Kieran Madre
        /// Date: 2/1/2024
        /// Purpose: handle the inputs every frame
        /// </summary>
        /// <param name="player">player instance</param>
        /// <param name="gameTime">gametime instance</param>
        public void InputScript(Player player)
        {
            input.PlayerInputHandler(player);
        }

        /// <summary>
        /// Programmer: Kieran Madre
        /// Date: 2/1/2024
        /// Purpose: abstract the speed reset each frame
        /// </summary>
        public void ResetSpeed()
        {
            this.CurrentSpeed = Speed;
        }

        public void kill()
        {
            this.Lives--;
            if(this.Lives == -1)
            {
                Globals.PauseGame();
            }
            else
            {
                this.CenterPlayer();
            }
            ProjectileHandler projectileHandler = ProjectileHandler.GetProjectileHandler();
            projectileHandler.clearProjectiles();
        }

        /// <summary>
        /// Programmer: Kieran Madre
        /// Date: 2/1/2024
        /// Purpose: abstraction of  player centering
        /// </summary>
        private void CenterPlayer()
        {

            float height = 720f;
            float width = 500f;

            Vector2 position = new Vector2(width*0.475f, height*0.9f);
            this.Position = position;
        }

        /// <summary>
        /// Programmer:Kieran Madre
        /// Date: 1/31/2024
        /// Purpose: Assign appropriate values that are returned from the interpreter
        /// </summary>
        private void LoadPlayerScript()
        {
            PlayerScriptInterpreter playerScriptInterpreter = new PlayerScriptInterpreter("PlayerScript.json");
            string valsConcated = playerScriptInterpreter.JsonInterpreter();
            string[] vals = valsConcated.Split(',');

            this.CurrentLives = int.Parse(vals[0]);
            this.Lives = int.Parse(vals[0]);
            
            this.CurrentSpeed = float.Parse(vals[1]);
            this.Speed = float.Parse(vals[1]);
        }

        /// <summary>
        /// Programmer: Kieran Madre
        /// Date: 2/1/2024
        /// Purpose: Texture loader for player
        /// </summary>
        /// <param name="content"></param>
        public void LoadTexture()
        {
            this.Texture = Globals.Content.Load<Texture2D>(this.TextureName);
        }

        public void updateHitbox()
        {
            this.hitbox.X = (int)this.Position.X;
            this.hitbox.Y = (int)this.Position.Y;
        }

        private void updateLivesFromDifficulty()
        {
            switch (Globals.getDifficulty())
            {
                case "Easy": this.Lives = 9;
                    break;
                case "Normal": this.Lives = 6;
                    break;
                case "Hard": this.Lives = 3;
                    break;
            }
        }

        public void IncreaseHealth()
        {
            this.Lives++;
        }

        public void IncreaseDamage(float increase)
        {
            this.gun.IncreaseDamage(increase);
        }

        public void IncreaseFireRate(float increase)
        {
            this.gun.IncreaseFireRate(increase);
        }

        public void IncreaseSpeed(float increase)
        {
            this.Speed += increase;
        }
    }// class end
}// namespace end
