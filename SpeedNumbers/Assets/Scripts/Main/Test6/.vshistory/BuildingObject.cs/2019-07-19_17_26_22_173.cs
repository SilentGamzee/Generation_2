using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main.Test6
{
    public class BuildingObject : MonoBehaviour
    {
        public List<Sprite> upgrades;
        public int upgrade_cost;
        public int upgrade_mult;
        public int training_time;
        public int exp_count;
        public bool isStadion;


        private int building_lvl;

        private float training_t = 0;
        private bool is_training = false;
        public void OnChoose(Text text, Text cost_text)
        {
            if (!is_training)
                ButtonListener._instance.city_bottom_button.interactable = true;
            if (isStadion)
            {
                text.text = "Enter the stadium";
                ButtonListener._instance.city_bottom_upgrade_button.gameObject.SetActive(false);
            }
            else
            {
                text.text = "Take exercise";
                ButtonListener._instance.city_bottom_upgrade_button.gameObject.SetActive(true);
            }

            var cost = 
            cost_text.text = "cost: " + (upgrade_cost + building_lvl * upgrade_mult);

        }

        public void OnButton()
        {
            if (is_training) return;
            if (isStadion)
            {
                return;
            }
            ButtonListener._instance.city_bottom_button.interactable = false;
            is_training = true;
        }

        public void OnUpgradeButton()
        {

        }

        void Update()
        {
            if (!is_training) return;
            training_t += Time.deltaTime;
            var time = training_time - (int)training_t;
            if (time <= 0)
            {
                ButtonListener._instance.city_bottom_button.interactable = true;
                transform.GetChild(0).gameObject.SetActive(false);
                is_training = false;
                training_t = 0;
                PlayerManager.EXP += exp_count + building_lvl * exp_count;
                return;
            }
            var time_obj = transform.GetChild(0).gameObject;
            time_obj.SetActive(true);
            time_obj.GetComponent<Text>().text = "Time left:\n" + time;

        }

    }
}
