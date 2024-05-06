using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retribution.PlayerRelated
{
    internal interface IUpgradeable
    {
        public void IncreaseHealth();
        public void IncreaseDamage(float increase);
        public void IncreaseFireRate(float increase);
        public void IncreaseSpeed(float increase);

    }
}
