using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Retribution.Projectiles.ProjectilePaths;

namespace Retribution.Projectiles.ProjectileTypes
{
    public abstract class BaseProjectile
    {

        public Vector2 Position;

        public Rectangle hitbox;

        public BaseProjectilePath path;

        public float projectileSize;
        public float projectileSpeed;
        public float damage;
        public bool FiredUp;
        public float Spread;
        public int randomnessDirection;
        public float randomness;

        public BaseProjectile(Vector2 pos, float size, float speed, float dmg, bool FireUp, float spread)
        {
            this.Position.X = pos.X;
            this.Position.Y = pos.Y;
            this.hitbox = new Rectangle((int)pos.X, (int)pos.Y, (int)size, (int)size);
            this.projectileSize = size;
            this.projectileSpeed = speed;
            this.damage = dmg;
            this.FiredUp = FireUp;
            this.Spread = spread;
            Random rand = new Random();
            this.randomnessDirection = (int)rand.Next() % 2;
            this.randomness = (float)rand.NextDouble();

            this.path = new LinearProjectilePath();
        }

        public void Path(BaseProjectile projectile)
        {
            this.path.ProjectilePath(projectile);
        }
    }
}
