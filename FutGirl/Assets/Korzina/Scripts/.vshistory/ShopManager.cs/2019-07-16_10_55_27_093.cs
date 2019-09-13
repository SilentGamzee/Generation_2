using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Korzina.Scripts
{
    public class ShopManager : MonoBehaviour
    {
        public GameObject shop_panel;
        public Button button;
        public GameObject row_1;
        public GameObject row_2;
        public GameObject upgradeButton_prefab;
        public List<Sprite> button_images;
        public Text money_text;
        public Button exit_shop_button;
        public Sprite chosenSpriteBG;
        public Sprite normalSpriteBG;

        private static Dictionary<Button, int> upgradeDict = new Dictionary<Button, int>();
        private static Dictionary<Button, int> upgradeGirlIndexes = new Dictionary<Button, int>();
        private static Button current_upgrade
        {
            get => current_upgrade1;
            set
            {
                var prev = current_upgrade;
                current_upgrade1 = value;
                if (prev != null)
                    prev.GetComponent<Image>().sprite = _instance.normalSpriteBG;
                value.GetComponent<Image>().sprite = _instance.chosenSpriteBG;
                Debug.Log("Setting: " + upgradeGirlIndexes[value]);
                LevelController._instance.SetImageIndex(upgradeGirlIndexes[value]);
            }
        }

        public int cost;
        public float cost_mult;
        public static ShopManager _instance;
        private static Button current_upgrade1;

        void Start()
        {
            _instance = this;
            SaveInfo.Start();

            SaveInfo.ClearSave();

            exit_shop_button.onClick.AddListener(OnCloseShop);
            button.onClick.AddListener(OnOpenShop);

            OnMoneyChanged(PlayerManager._instance.goals);

            for (var i = 0; i < PlayerManager._instance.Tiers_count; i++)
            {
                var butt = Instantiate(upgradeButton_prefab, row_1.transform);
                var trans = butt.transform;
                var cost_text = trans.GetChild(0).GetComponent<Text>();
                cost_text.text = "" + cost;
                var butt_b = butt.GetComponent<Button>();
                butt_b.interactable = false;
                butt_b.onClick.AddListener(delegate { OnUpgrade(butt_b); });
                if (i > 0)
                {
                    upgradeDict.Add(butt_b, cost);
                    upgradeGirlIndexes.Add(butt_b, TierObject.GetIndexByTier(i + 1));
                    cost = (int)(cost * cost_mult);
                }
                else
                {
                    SaveInfo.upgrades.Add(0)
                }

                var tier_text = trans.GetChild(1).GetComponent<Text>();
                tier_text.text = "Buy Girls Tier " + (i + 1);

                var sprite = button_images[i];
                var image = trans.GetChild(2).GetComponent<Image>();
                image.sprite = sprite;
            }
            foreach (var i in upgradeGirlIndexes.Values)
            {
                Debug.Log(i);
            }
            SaveInfo.upgrades.ForEach(x =>
            {
                foreach (var kv in upgradeDict)
                {
                    var k = kv.Key;
                    var v = kv.Value;
                    if (x == v)
                    {
                        var cost_text = k.transform.GetChild(0).GetComponent<Text>();
                        cost_text.text = "Purchased";
                        k.interactable = false;
                        current_upgrade = k;

                    }
                }
            });
        }

        void OnUpgrade(Button b)
        {
            var manager = PlayerManager._instance;
            if (SaveInfo.upgrades.Contains(upgradeDict[b]))
            {
                current_upgrade = b;
                return;
            }
            if (manager.goals < upgradeDict[b]) return;
            SaveInfo.upgrades.Add(upgradeDict[b]);


            manager.goals -= upgradeDict[b];
            var cost_text = b.transform.GetChild(0).GetComponent<Text>();
            cost_text.text = "Purchased";

            b.interactable = false;
            current_upgrade = b;
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
            foreach (var kv in upgradeDict)
            {
                var butt = kv.Key;
                var cost = kv.Value;
                if (money >= cost)
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
