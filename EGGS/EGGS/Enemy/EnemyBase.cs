using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGGS.Enemy
{
    internal class EnemyBase
    {

        public int CurrentHealth { get; set; } // Lives updates in live game
        public float CurrentSpeed { get; set; }  // speed updates in live game
        private int Health;  // Max Lives that was set
        private float Speed; // Max speed that was set

        public Vector2 Position { get; set; }
        public string TextureName { get; }
        public Texture2D Texture;
        private EnemyMovement movement;

    }
}
