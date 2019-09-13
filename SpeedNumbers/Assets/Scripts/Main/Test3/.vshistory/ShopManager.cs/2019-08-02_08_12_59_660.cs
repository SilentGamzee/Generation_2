
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main.Test3
{
    public class ShopManager : MonoBehaviour
    {
        public GameObject error_shop_text;
        public Button exitShop;

        public static ShopManager _instance;

        const string error_money = "Not enough money";
        const string error_level = "Not enough levels";

        private static float t = 0;
        public static void OnNotEnoughMoney()
        {
            t = 2f;
            _instance.error_shop_text.GetComponent<Text>().text = error_money;
            _instance.error_shop_text.SetActive(true);
        }

        public static void OnNotEnoughLevel()
        {
            t = 2f;
            _instance.error_shop_text.GetComponent<Text>().text = error_level;
            _instance.error_shop_text.SetActive(true);
        }

        void Start()
        {
            _instance = this;
            exitShop.onClick.AddListener(OnExitShop);
        }

        void OnExitShop()
        {
            PanelManager.Get().shop_panel.SetActive(false);
        }

        void Update()
        {
            if (t <= 0) return;
            t -= Time.deltaTime;
            if (t <= 0)
                error_shop_text.SetActive(false);
            
        }
    }
}
