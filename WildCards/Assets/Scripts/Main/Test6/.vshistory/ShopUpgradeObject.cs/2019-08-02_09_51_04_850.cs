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
        public int upgrade_id;

        const string speed_title = "Upgrade bullet speed";
        const string switch_title = "Upgrade reload speed";
        const string training_title = "Upgrade coins drop";

        int total_cost = 0;
        void Awake()
        {
            
        }
        void Start()
        {
            total_cost = cost + cost * cost_mult;
            gameObject.GetComponent<Button>().onClick.AddListener(delegate { OnUpgrade(true); });
            transform.GetChild(0).GetComponent<Text>().text = "cost: " + total_cost;

            string prefix = "";
            switch (upgrade_id)
            {
                case 0: prefix = speed_title; break;
                case 1: prefix = switch_title; break;
                case 2: prefix = training_title; break;
            }
            transform.GetChild(1).GetComponent<Text>().text = prefix;
        }
        public void OnUpgrade(bool safe)
        {
            if (safe)
            {
                
                if (PlayerManager.Points < cost)
                {
                    ShopManager.OnNotEnoughMoney();
                    return;
                }
            }

            PlayerManager.Points -= cost;
            

            total_cost = cost + cost  * cost_mult;
           
            transform.GetChild(0).GetComponent<Text>().text = "cost: " + total_cost;
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
            transform.GetChild(1).GetComponent<Text>().text = prefix;
            SaveInfo.OnSave();
        }
    }
}
