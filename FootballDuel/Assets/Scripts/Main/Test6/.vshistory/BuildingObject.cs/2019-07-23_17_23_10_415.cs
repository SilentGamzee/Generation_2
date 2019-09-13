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

       


        public void OnChoose(Text text)
        {
            if (isStadion)
            {
                text.text = "Enter the arena";
                
            }
            else
            {
                text.text = "Shop";
            }


           
        }

       

        public void OnButton()
        {
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
            shop_panel.SetActive(!shop_panel.activeSelf);
        }

       

    }
}
