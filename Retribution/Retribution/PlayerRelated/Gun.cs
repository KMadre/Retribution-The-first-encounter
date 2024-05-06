using Retribution.Projectiles;
using Retribution.ScriptReader;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Retribution.Projectiles.ProjectileFactories;
using Retribution.Projectiles.ProjectileTypes;

namespace Retribution.PlayerRelated
{
    /// <summary>
    /// Programmer: Kieran Madre
    /// Date: 2/1/2024
    /// Purpose: the logic to handle the players projectiles
    /// </summary>
    public class Gun : IUpgradeable
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

        private float sinceLast;
        private float baseCD;

        private PlayerDefaultProjectileFactory factory;

        internal Gun()
        {
            LoadScript();
            this.factory = new PlayerDefaultProjectileFactory();

            this.sinceLast = 0f;
            baseCD = 1/(FireRate / 60);
        }

        /// <summary>
        /// Programmer:Kieran Madre
        /// Date: 2/1/2024
        /// Purpose: spawns in a projectile from the player with gun stats
        /// </summary>
        /// <param name="projectileFactory"></param>
        public void shoot(Player player)
        {
            this.sinceLast += Globals.Time;
            if (checkCD())
            {
                Microsoft.Xna.Framework.Vector2 pos_ = player.Position;
                pos_.X += 12;//center projectile
                PlayerProjectile projectile;
                projectile = factory.createProjectile(pos_, currProjectileSize, currProjectileSpeed, currDamage, true, spread);
                ProjectileHandler projectileHandler = ProjectileHandler.GetProjectileHandler();
                projectileHandler.ProjectileList.Add(projectile);
            }
            
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
        private bool checkCD()
        {
            if (sinceLast >= baseCD)
            {
                this.sinceLast = 0f;
                return true;
            }
            return false;
        }

        private void UpdateFireRate()
        {
            baseCD = 1 / (currFireRate / 60);
        }

        public void IncreaseHealth()
        {
            throw new NotImplementedException();
        }

        public void IncreaseDamage(float increase)
        {
            this.currDamage += (int)increase;
        }

        public void IncreaseFireRate(float increase)
        {
            this.currFireRate += increase;
            UpdateFireRate();
        }

        public void IncreaseSpeed(float increase)
        {
            throw new NotImplementedException();
        }
    }
}
