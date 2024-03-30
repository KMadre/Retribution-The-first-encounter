using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retribution.Projectiles.ProjectileTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Retribution.Projectiles.ProjectileFactories
{
    public class PlayerDefaultProjectileFactory
    {

        public PlayerDefaultProjectileFactory()
        {

        }

        public PlayerProjectile createProjectile(Vector2 pos, float size, float speed, float dmg, bool FireUp, float spread)
        {
            PlayerProjectile playerProjectile = new PlayerProjectile(pos, size, speed, dmg, FireUp, spread);
            return playerProjectile;
        }

    }
}
