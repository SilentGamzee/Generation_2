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

        void Start()
        {
            gameObject.GetComponent<Button>().onClick.AddListener(OnUpgrade);
            transform.GetChild(0).GetComponent<Text>().text = "cost: " + cost;
        }
        void OnUpgrade()
        {
            switch (upgrade_id)
            {
                case 0: PlayerManager.player_speed_lvl++; break;
                case 1: PlayerManager.player_switch_lvl++; break;
                case 2: PlayerManager.player_training_lvl++; break;
            }
        }
    }
}
