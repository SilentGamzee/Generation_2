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
        public Text money_text;

        private static Dictionary<Button, int> upgradeDict = new Dictionary<Button, int>();

        public int cost;
        public float cost_mult;
        public static ShopManager _instance;
        void Start()
        {
            _instance = this;
            
           
            OnMoneyChanged(PlayerManager._instance.goals);

            for(var i = 0; i < PlayerManager._instance.Tiers_count; i++)
            {
                GameObject panel;
                if (PlayerManager._instance.Tiers_count / 2 > i)
                    panel = row_1;
                else
                    panel = row_2;
                

                var butt = Instantiate(upgradeButton_prefab, panel.transform);
                var trans = butt.transform;
                var cost_text = trans.GetChild(0).GetComponent<Text>();
                cost_text.text = ""+cost;
                var butt_b = butt.GetComponent<Button>();
                butt_b.onClick.AddListener(delegate { OnUpgrade(butt_b); });
                upgradeDict.Add(butt_b, cost);
                cost = (int)(cost * cost_mult);

                var tier_text = trans.GetChild(1).GetComponent<Text>();
                tier_text.text = "Buy Girls Tier "+(i+1);

                var sprite = button_images[i];
                var image = trans.GetChild(2).GetComponent<Image>();
            }
        }

        void OnUpgrade(Button b)
        {
            var manager = PlayerManager._instance;
            if (manager.goals < cost) return;
            manager.max_tier++;
            if(manager.max_tier == manager.Tiers_count)
                button.gameObject.SetActive(false);
            
            manager.goals -= cost;

            b.gameObject.SetActive(false);
        }

        public static void OnMoneyChanged(int money)
        {
            _instance.money_text.text = "" + money;
            /*
             
            if (_instance.cost > money)
                _instance.button.interactable = false;
            else
                _instance.button.interactable = true;
                */
        }
    }
}
