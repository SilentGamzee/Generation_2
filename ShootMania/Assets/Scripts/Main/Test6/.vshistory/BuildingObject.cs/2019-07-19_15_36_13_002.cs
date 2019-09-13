using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main.Test6
{
    public class BuildingObject:MonoBehaviour
    {
        public List<Sprite> upgrades;
        public int upgrade_cost;
        public int upgrade_mult;
        public int training_time;
        public bool isStadion;

        private int building_lvl;

        void OnChoose(Text text)
        {
            if (isStadion)
                text.text = "Enter the stadium";
            else
                text.text = "Take exercise";
        }

    }
}
