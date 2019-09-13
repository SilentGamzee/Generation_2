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

        public void OnChoose(Text text)
        {
            ButtonListener._instance.city_bottom_button.interactable = !is_training;

            
            if (isStadion)
            {
                text.text = "Enter the stadium";
                
            }
            else
            {
                text.text = "Take exercise";
               
            }

            cost = upgrade_cost + building_lvl * upgrade_mult * upgrade_cost;
           
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
                ButtonListener.Lives = ButtonListener.Lives_max;
                ButtonListener.LivesEnemy = ButtonListener.Lives_max_enemy;
                ButtonListener.Lives_max_enemy++;
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
           

        }

    }
}
