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
    /// Purpose: Abstract class that represents a projectile
    /// </summary>
    public class Projectile
    {
        public Vector2 Position;
        public float projectileSize;
        private float projectileSpeed;
        public float damage;
        bool FiredUp;
        //private string TextureName;
        public Texture2D Texture;
        private float Spread;
        private int randomnessDirection;
        private float randomness;

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
        public Projectile(Vector2 pos, float size, float speed, float dmg, Texture2D texture, bool FireUp, float spread)
        {
            this.Position = pos;
            this.projectileSize = size;
            this.projectileSpeed = speed;
            this.damage = dmg;
            this.Texture = texture;
            this.FiredUp = FireUp;
            this.Spread = spread;
            Random rand = new Random();
            this.randomnessDirection = (int)rand.Next() % 2;
            this.randomness = (float)rand.NextDouble();
        }

        /// <summary>
        /// Programmer: Kieran Madre
        /// Date: 2/1/2024
        /// Purpose: handle the pathing updates of the projectiles
        /// </summary>
        /// <param name="gameTime"></param>
        public void ProjectilePath()
        {
            if (FiredUp)
            {
                Vector2 pos = this.Position;
                pos.Y -= this.projectileSpeed * (float)Globals.Time;
                this.Position = pos;
            }
            else
            {
                Vector2 pos = this.Position;
                pos.Y += this.projectileSpeed * (float)Globals.Time;
                this.Position = pos;
            }

            if(this.Spread != 0f)
            {
                Vector2 pos = this.Position;
                if(this.randomnessDirection == 1)
                {
                    pos.X += (randomness * this.Spread) * (float)Globals.Time;
                    this.Position = pos;
                }
                else
                {
                    pos.X -= (randomness * this.Spread) * (float)Globals.Time;
                    this.Position = pos;
                }
            }
        }
    }
}
