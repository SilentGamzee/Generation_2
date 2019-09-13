using Assets.Scripts.Main.Test3;
using Assets.Scripts.Main.Test6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main
{
    class ButtonListener : MonoBehaviour
    {
     
        public Button PauseButton;
        public Button shopButton;

        public Transform top;
        public Transform bottom;

        public List<ShopUpgradeObject> upgrades;

        public Button adsOpen;
        public Button adsExit;
        public GameObject adsPanel;


        public static ButtonListener _instance;

     


        public static int Lives
        {
            get => lives;
            set
            {
                lives = value;
                // _instance.lives_text.text = "" + value;
                if (value <= 0)
                {
                    var p = PlayerManager.P;
                    PlayerManager.Points += p * PlayerManager._instance.pointsWin;
                    lives = Lives_max;
                }
            }
        }
        public static int Lives_max = 3;
        
        void Start()
        {
            _instance = this;

            SaveInfo.OnStart();

            Lives = Lives_max;
       
            shopButton.onClick.AddListener(OnShop);
            PauseButton.onClick.AddListener(MenuManager.OnReturn);


            adsExit.onClick.AddListener(OnAdsExit);
            adsOpen.onClick.AddListener(OnAdsOpen);
        }

        void OnAdsExit()
        {
            adsPanel.SetActive(false);
        }

        void OnAdsOpen()
        {
            adsPanel.SetActive(true);
        }

        void OnShop()
        {
            PanelManager.Get().shop_panel.SetActive(!PanelManager.Get().shop_panel.activeSelf);
        }

        public static void ResetStats()
        {

        }

        
        private static int lives;
      
       
    }
}
