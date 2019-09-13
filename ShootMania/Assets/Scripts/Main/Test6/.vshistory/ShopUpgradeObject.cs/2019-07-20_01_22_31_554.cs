using Assets.Scripts.Main.Test3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main.Test6
{
    public class ShopUpgradeObject : MonoBehaviour
    {
        public int cost;
        public int cost_mult;
        public int require_lvl;
        public int upgrade_id;

        const string speed_title = "Upgrade players speed";
        const string switch_title = "Upgrade switching speed";
        const string training_title = "Upgrade training speed";

        void Start()
        {
            gameObject.GetComponent<Button>().onClick.AddListener(OnUpgrade);
            transform.GetChild(0).GetComponent<Text>().text = "cost: " + cost;

            string prefix = "";
            switch (upgrade_id)
            {
                case 0: PlayerManager.player_speed_lvl++; break;
                case 1: PlayerManager.player_switch_lvl++; break;
                case 2: PlayerManager.player_training_lvl++; break;
            }
            transform.GetChild(1).GetComponent<Text>().text = "cost: " + cost;
        }
        void OnUpgrade()
        {
            if (PlayerManager.Points < cost)
            {
                ShopManager.OnNotEnoughMoney();
                return;
            }
            PlayerManager.Points -= cost;
            cost *= cost_mult;
            require_lvl++;
            switch (upgrade_id)
            {
                case 0: PlayerManager.player_speed_lvl++; break;
                case 1: PlayerManager.player_switch_lvl++; break;
                case 2: PlayerManager.player_training_lvl++; break;
            }
            transform.GetChild(0).GetComponent<Text>().text = "cost: " + cost;

        }
    }
}
