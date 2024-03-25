using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retribution.ScriptReader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Retribution.Projectiles;

/// <summary>
/// Programmer: Kieran Madre
/// Date: 2/1/2024
/// Purpose: create a class that encompasses all of the players movement options
/// </summary>
namespace Retribution.PlayerRelated
{
    /// <summary>
    /// References used!!!!
    /// Link: https://monogame.net/articles/getting_started/5_adding_basic_code/
    /// </summary>
    internal class PlayerInput
    {

        private float slowMultiplier;
        private float sprintMultiplier;

        internal PlayerInput()
        {
            this.slowMultiplier = 0;
            this.sprintMultiplier = 0;
            LoadPlayerInputScript();
        }

        /// <summary>
        /// Programmer: Kieran Madre
        /// Date: 2/1/2024
        /// Purpose: load input multiplier file
        /// </summary>
        private void LoadPlayerInputScript()
        {
            PlayerInputInterpreter playerInputInterpreter = new PlayerInputInterpreter("PlayerInputMultiplierScript.json");
            string valsConcated = playerInputInterpreter.JsonInterpreter();
            string[] vals = valsConcated.Split(',');

            this.slowMultiplier = float.Parse(vals[0]);
            this.sprintMultiplier = float.Parse(vals[1]);
        }

        /// <summary>
        /// Programmer: Kieran Madre
        /// Date: 2/1/2024
        /// Purpose: Allow the user to move the player character.
        /// </summary>
        /// <param name="player">player instance</param>
        /// <param name="gameTime">gametime instance. Needed to make character move with time passed instead of framerate</param>
        public void PlayerInputHandler(Player player)
        {
            player.ResetSpeed(); // reset the users speed every frame
            var userButton = Keyboard.GetState(); // grab what button is currently being pressed down

            // Check for Slowdown
            if (userButton.IsKeyDown(Keys.LeftShift))
            {
                player.CurrentSpeed /= this.slowMultiplier;
            }else if (userButton.IsKeyDown(Keys.LeftControl))
            {
                player.CurrentSpeed *= this.sprintMultiplier;
            }

            // directional movement
            if (userButton.IsKeyDown(Keys.A))
            {
                Vector2 pos = player.Position; // copy the player val
                pos.X -= player.CurrentSpeed * (float)Globals.Time; // update based on game time
                player.Position = pos; // update player position with new value
            }
            if (userButton.IsKeyDown(Keys.D))
            {
                Vector2 pos = player.Position;
                pos.X += player.CurrentSpeed * (float)Globals.Time;
                player.Position = pos;
            }
            if (userButton.IsKeyDown(Keys.W))
            {
                Vector2 pos = player.Position;
                pos.Y -= player.CurrentSpeed * (float)Globals.Time;
                player.Position = pos;
            }
            if (userButton.IsKeyDown(Keys.S))
            {
                Vector2 pos = player.Position;
                pos.Y += player.CurrentSpeed * (float)Globals.Time;
                player.Position = pos;
            }

            //Shoot gun
            if (userButton.IsKeyDown(Keys.Space))
            {
                player.gun.shoot(player);
            }

            player.updateHitbox();
        }
    }// class end
}//namespace end
