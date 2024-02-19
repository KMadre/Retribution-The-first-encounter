using Retribution.Projectiles;
using Retribution.ScriptReader;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Retribution.PlayerRelated
{
    /// <summary>
    /// Programmer: Kieran Madre
    /// Date: 2/1/2024
    /// Purpose: the logic to handle the players projectiles
    /// </summary>
    public class Gun
    {
        private float spread;

        private int currDamage;
        private int Damage;

        private float currFireRate;
        private float FireRate;

        private float currProjectileSize;
        private float ProjectileSize;

        private float currProjectileSpeed;
        private float ProjectileSpeed;

        internal Gun()
        {
            LoadScript();
        }

        /// <summary>
        /// Programmer:Kieran Madre
        /// Date: 2/1/2024
        /// Purpose: spawns in a projectile from the player with gun stats
        /// </summary>
        /// <param name="projectileFactory"></param>
        public void shoot(ProjectileFactory projectileFactory, Player player, GameTime gameTime)
        {
            Microsoft.Xna.Framework.Vector2 pos_ = player.Position;
            pos_.X += 12;//center projectile
            projectileFactory.SpawnProjectile(pos_, currProjectileSize, currProjectileSpeed, currDamage, true, spread);
        }

        /// <summary>
        /// Programmer: Kieran Madre
        /// Date: 2/1/2024
        /// Purpose: loads gun info script
        /// </summary>
        private void LoadScript()
        {
            PlayerGunInterpreter playerScriptInterpreter = new PlayerGunInterpreter("PlayerGun.json");
            string valsConcated = playerScriptInterpreter.JsonInterpreter();
            string[] vals = valsConcated.Split(',');

            this.spread = float.Parse(vals[0]);

            this.currDamage = int.Parse(vals[1]);
            this.Damage = int.Parse(vals[1]);

            this.FireRate = float.Parse(vals[2]);
            this.currFireRate = float.Parse(vals[2]);

            this.currProjectileSize = int.Parse(vals[3]);
            this.ProjectileSize = int.Parse(vals[3]);

            this.ProjectileSize = float.Parse(vals[4]);
            this.currProjectileSpeed = float.Parse(vals[4]);
        }
    }
}
