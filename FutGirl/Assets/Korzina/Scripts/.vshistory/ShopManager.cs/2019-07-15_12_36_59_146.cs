using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Korzina.Scripts
{
    public class ShopManager:MonoBehaviour
    {
        public Button button;
        public Text cost_text;

        public int cost;
        public float cost_mult;

        void Start()
        {
            button.onClick.AddListener(OnUpgrade);
            cost_text.text = "cost: " + cost;
        }

        void OnUpgrade()
        {
            var manager = PlayerManager._instance;
            if (manager.goals < cost) return;
            manager.max_tier++;
            if(manager.max_tier == manager.Tiers_count)
                button.gameObject.SetActive(false);
            
            manager.goals -= cost;
            cost = (int)(cost * cost_mult);
            cost_text.text = "cost: " + cost;
        }

        public static void OnMoneyChanged(int money)
        {

        }
    }
}
