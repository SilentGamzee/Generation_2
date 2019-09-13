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


        public int building_lvl
        {
            get => building_lvl1;
            set
            {
                if (value > upgrades.Count || value <= 0) return;
                building_lvl1 = value;
                this.gameObject.GetComponent<Image>().sprite = upgrades[value - 1];
            }
        }

        private float training_t = 0;
        private bool is_training = false;
        private int cost;
        private int building_lvl1;

        public void OnChoose(Text text, Text cost_text)
        {
            ButtonListener._instance.city_bottom_button.interactable = !is_training;

            ButtonListener._instance.city_bottom_upgrade_button.gameObject.SetActive(building_lvl+1 < upgrades.Count);
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

            cost = upgrade_cost + building_lvl * upgrade_mult * upgrade_cost;
            cost_text.text = "cost: " + cost;

            ButtonListener._instance.city_bottom_upgrade_button.interactable = PlayerManager.Points >= cost;
        }

        public void OnMoneyChange()
        {
            ButtonListener._instance.city_bottom_upgrade_button.interactable = PlayerManager.Points >= cost;
        }

        public void OnButton()
        {
            if (is_training)
                return;

            if (isStadion)
            {
                ButtonListener._instance.city_panel.SetActive(false);
                ButtonListener._instance.playground_panel.SetActive(true);
                MoveCoordinator.ResetPosition();
                
                GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
                return;
            }
            ButtonListener._instance.city_bottom_button.interactable = false;
            is_training = true;
        }

        public void OnUpgradeButton()
        {
            ButtonListener._instance.city_bottom_upgrade_button.gameObject.SetActive(building_lvl + 1 < upgrades.Count);
            PlayerManager.Points -= cost;
            building_lvl++;

            cost = upgrade_cost + building_lvl * upgrade_mult * upgrade_cost;
            ButtonListener._instance.city_bottom_upgrade_cost.text = "cost: " + cost;
            SaveInfo.OnSave();
        }

        void Update()
        {
            if (!is_training) return;
            training_t += Time.deltaTime;
            var time = training_time - (int)training_t - (PlayerManager.player_training_lvl * 2);
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
