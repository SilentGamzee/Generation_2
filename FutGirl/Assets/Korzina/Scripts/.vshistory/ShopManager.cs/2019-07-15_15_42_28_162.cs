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
        public GameObject row_1;
        public GameObject row_2;
        public GameObject upgradeButton_prefab;
        public List<Sprite> button_images;

        public Text cost_text;

        public int cost;
        public float cost_mult;
        public static ShopManager _instance;
        void Start()
        {
            _instance = this;
            button.onClick.AddListener(OnUpgrade);
            cost_text.text = "cost: " + cost;
            OnMoneyChanged(PlayerManager._instance.goals);

            for(var i = 0; i < PlayerManager._instance.Tiers_count; i++)
            {
                var butt = Instantiate(upgradeButton_prefab, panel.transform);
                var trans = butt.transform;
                var cost_text = trans.GetChild(0).GetComponent<Text>();
                cost_text.text = ""+cost;
                cost = (int)(cost * cost_mult);

                var tier_text = trans.GetChild(1).GetComponent<Text>();
                tier_text.text = "Buy Girls Tier "+(i+1);

                var sprite = button_images[i];

            }
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
            if (_instance.cost > money)
                _instance.button.interactable = false;
            else
                _instance.button.interactable = true;
        }
    }
}
