using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main
{
    class PreEndCalculator : MonoBehaviour
    {

        private static int points;

        void CalcSecondary()
        {
            points = 0;
            var rows = InitScript._instance.gameRows;
            foreach(var row in rows)
            {
                var trans = row.transform;
                var valid = true;
                for(var i = 0; i < trans.childCount; i++)
                {
                    var 
                }
            }
        }

        void Update()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.PreEnd) return;

        }
    }
}
