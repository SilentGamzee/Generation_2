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

        const string speed_title = "Upgrade players speed ";
        const string switch_title = "Upgrade switching speed ";
        const string training_title = "Upgrade training speed ";

        int first_cost = 0;
        void Start()
        {
            first_cost = cost;
            gameObject.GetComponent<Button>().onClick.AddListener(delegate { OnUpgrade(true); });
            transform.GetChild(0).GetComponent<Text>().text = "cost: " + cost;

            string prefix = "";
            switch (upgrade_id)
            {
                case 0: prefix = speed_title; break;
                case 1: prefix = switch_title; break;
                case 2: prefix = training_title; break;
            }
            transform.GetChild(1).GetComponent<Text>().text = prefix + " level " + require_lvl;
        }
        public void OnUpgrade(bool safe)
        {
            if (safe)
            {
                if (PlayerManager.level < require_lvl)
                {
                    ShopManager.OnNotEnoughLevel();
                    return;
                }

                if (PlayerManager.Points < cost)
                {
                    ShopManager.OnNotEnoughMoney();
                    return;
                }
            }

            PlayerManager.Points -= cost;
            
            require_lvl++;
            cost = first_cost + first_cost * require_lvl * cost_mult;
            transform.GetChild(0).GetComponent<Text>().text = "cost: " + cost;
            switch (upgrade_id)
            {
                case 0: PlayerManager.player_speed_lvl++; break;
                case 1: PlayerManager.player_switch_lvl++; break;
                case 2: PlayerManager.player_training_lvl++; break;
            }
            

            string prefix = "";
            switch (upgrade_id)
            {
                case 0: prefix = speed_title; break;
                case 1: prefix = switch_title; break;
                case 2: prefix = training_title; break;
            }
            transform.GetChild(1).GetComponent<Text>().text = prefix + " level " + require_lvl;
            SaveInfo.OnSave();
        }
    }
}
