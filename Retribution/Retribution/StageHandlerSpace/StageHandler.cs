using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retribution.StageHandler.StageDesignFactorySpace;
using Retribution.StageHandler.EnemyHandlerSpace;


namespace Retribution.StageHandlerSpace
{
    public class StageHandler
    {
        private int Phase { get; set; }
        private int Phases_amount;
        private List<int> Phase_timers;
        private List<StageDesignFactory> stageDesigns;
        private EnemyHandler enemyHandler;

        public StageHandler() 
        {

            //LoadStageScript();
            enemyHandler = new EnemyHandler(50, false, 50);

        }

        public void LoadStageScript()
        {

        }

    }
}
