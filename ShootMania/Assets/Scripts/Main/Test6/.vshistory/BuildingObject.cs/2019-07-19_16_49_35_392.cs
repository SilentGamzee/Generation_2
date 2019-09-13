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

        public void OnChoose(Text text, Text cost_text)
        {
            if (isStadion)
            {
                text.text = "Enter the stadium";
                ButtonListener._instance.city_bottom_upgrade_button.gameObject.SetActive(false);
            }
            else
            {
                text.text = "Take exercise";
            }

            cost_text.text = "cost: " + (upgrade_cost + building_lvl * upgrade_mult);
        }

        public void OnButton()
        {
            Debug.Log("OnButton: "+isStadion);
        }

    }
}
