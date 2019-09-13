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
        }

        void OnUpgrade()
        {
            PlayerManager._instance.max_tier++;
            cost = (int)(cost * cost_mult);
            cost_text.text = "cost: " + cost;
        }

        public static void OnMoneyChanged()
        {

        }
    }
}
