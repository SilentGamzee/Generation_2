using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Korzina.Scripts
{
    public class TierObject
    {

        public TierObject(int index)
        {
            var player_inst = PlayerManager._instance;
            var tiers_count = player_inst.Tiers_count;
            var girls_count = player_inst.Girls_count;
            var poses_count = player_inst.Poses_count;

            
            for(var i = 0; i < index; i++)
            {

            }
        }


        private void Calculate(int index)
        {

        }
    }
}
