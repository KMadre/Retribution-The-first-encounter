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

namespace Retribution.Projectiles
{
    /// <summary>
    /// Programmer:Kieran Madre
    /// Date: 2/1/2024
    /// Purpose: Factory for all projectiles in the game
    /// </summary>
    public class ProjectileFactory
    {
        public List<Projectile> ProjectileList;
        public Texture2D Texture;
        private string TextureName;
        private int ProjectileLimit;

        public ProjectileFactory()
        {
            this.ProjectileList = new List<Projectile>();
            this.TextureName = "Textures//DefaultProjectile";
            LoadScript();
        }

        /// <summary>
        /// Programmer:Kieran Madre
        /// Date: 2/1/2024
        /// </summary>
        /// <param name="pos">where</param>
        /// <param name="size">how big</param>
        /// <param name="speed">how fast</param>
        /// <param name="dmg">how much damage when colliding</param>
        /// <param name="texture">what texture</param>
        /// <param name="FireUp">is it supposed to go up or down</param>
        /// <param name="spread">how much random spread in the projectile</param>
        public void SpawnProjectile(Vector2 pos, float size, float speed, float dmg, bool FireUp, float spread)
        {
            Projectile projectile = new Projectile(pos, size, speed, dmg, this.Texture, FireUp, spread);
            this.ProjectileList.Add(projectile);
            if(this.ProjectileList.Count > this.ProjectileLimit)
            {
                this.ProjectileList.RemoveAt(0);//delete projectile when limit is exceeded
            }
        }

        /// <summary>
        /// Programmer:Kieran Madre
        /// Date: 2/1/2024
        /// Purpose: handle all projectiles pathing
        /// </summary>
        /// <param name="gameTime"></param>
        public void HandleProjectiles()
        {
            foreach(Projectile projectile in this.ProjectileList)
            {
                projectile.ProjectilePath();
            }
        }

        /// <summary>
        /// Programmer: Kieran Madre
        /// Date: 2/1/2024
        /// </summary>
        /// <param name="content"></param>
        public void LoadTexture(ContentManager content)
        {
            this.Texture = content.Load<Texture2D>(this.TextureName);
        }

        /// <summary>
        /// Programmer: Kieran Madre
        /// Date: 2/1/2024
        /// </summary>
        public void LoadScript()
        {
            ProjectileFactoryInterpreter projectileFactoryInterpreter = new ProjectileFactoryInterpreter("ProjectileFactoryScript.json");
            string valsConcated = projectileFactoryInterpreter.JsonInterpreter();
            string[] vals = valsConcated.Split(',');

            this.ProjectileLimit = int.Parse(vals[0]);
        }
    }
    
}
