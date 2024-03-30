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
    /// <summary>
    /// Programmer:Kieran Madre
    /// Date: 2/1/2024
    /// Purpose: Abstract class that represents a projectile
    /// </summary>
    public class PlayerProjectile : BaseProjectile
    {
        public PlayerProjectile(Vector2 pos, float size, float speed, float dmg, bool FireUp, float spread) : base(pos, size, speed, dmg, FireUp, spread)
        {
            this.path = new LinearProjectilePath();
        }
    }
}
