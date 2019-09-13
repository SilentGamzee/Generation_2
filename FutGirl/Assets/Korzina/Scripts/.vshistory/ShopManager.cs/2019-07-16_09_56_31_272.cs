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
        public GameObject shop_panel;
        public Button button;
        public GameObject row_1;
        public GameObject row_2;
        public GameObject upgradeButton_prefab;
        public List<Sprite> button_images;
        public Text money_text;
        public Button exit_shop_button;

        private static Dictionary<Button, int> upgradeDict = new Dictionary<Button, int>();
     
        public int cost;
        public float cost_mult;
        public static ShopManager _instance;
        void Start()
        {
            
            _instance = this;

            exit_shop_button.onClick.AddListener(OnCloseShop);
            button.onClick.AddListener(OnOpenShop);

            OnMoneyChanged(PlayerManager._instance.goals);

            for(var i = 0; i < PlayerManager._instance.Tiers_count; i++)
            {
                var butt = Instantiate(upgradeButton_prefab, row_1.transform);
                var trans = butt.transform;
                var cost_text = trans.GetChild(0).GetComponent<Text>();
                cost_text.text = ""+cost;
                var butt_b = butt.GetComponent<Button>();
                butt_b.interactable = false;
                butt_b.onClick.AddListener(delegate { OnUpgrade(butt_b); });
                upgradeDict.Add(butt_b, cost);
                cost = (int)(cost * cost_mult);

                var tier_text = trans.GetChild(1).GetComponent<Text>();
                tier_text.text = "Buy Girls Tier "+(i+1);

                var sprite = button_images[i];
                var image = trans.GetChild(2).GetComponent<Image>();
                image.sprite = sprite;
            }
        }

        void OnUpgrade(Button b)
        {
            var manager = PlayerManager._instance;
            if (manager.goals < upgradeDict[b]) return;
            SaveInfo.upgrades.Add(upgradeDict[b]); 
            manager.max_tier++;
            if(manager.max_tier == manager.Tiers_count)
                button.gameObject.SetActive(false);
            
            manager.goals -= upgradeDict[b];
            var cost_text = b.transform.GetChild(0).GetComponent<Text>();
            cost_text.text = "Purchased";

            b.interactable = false;
        }

        void OnOpenShop()
        {
            _instance.shop_panel.SetActive(true);
        }

        void OnCloseShop()
        {
            _instance.shop_panel.SetActive(false);
        }

        public static void OnMoneyChanged(int money)
        {
            _instance.money_text.text = "" + money;
            foreach(var kv in upgradeDict)
            {
                var butt = kv.Key;
                var cost = kv.Value;
                if (money >= cost && !SaveInfo.upgrades.Contains(cost))
                    butt.interactable = true;
                else
                    butt.interactable = false;
            }
            /*
             
            if (_instance.cost > money)
                _instance.button.interactable = false;
            else
                _instance.button.interactable = true;
                */
        }

        public static void End()
        {
            upgradeDict.Clear();
        }
    }
}
