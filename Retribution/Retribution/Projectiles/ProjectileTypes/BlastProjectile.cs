﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retribution.Projectiles.ProjectilePaths;

namespace Retribution.Projectiles.ProjectileTypes
{
    public class BlastProjectile : BaseProjectile
    {
        public BlastProjectile(Vector2 pos, float size, float speed, float dmg, bool FireUp, float spread) : base(pos, size, speed, dmg, FireUp, spread)
        {
            this.path = new SlowLinearPath();
        }
    }
}
