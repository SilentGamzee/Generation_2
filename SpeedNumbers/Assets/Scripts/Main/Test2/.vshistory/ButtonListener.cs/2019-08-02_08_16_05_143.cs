using Assets.Scripts.Main.Test3;
using Assets.Scripts.Main.Test6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main
{
    class ButtonListener : MonoBehaviour
    {
        public GameObject ball;
        public List<GameObject> myBalls;
        public List<GameObject> enemyBalls;
        public Button PauseButton;
        public Button shopButton;

        public Transform top;
        public Transform bottom;



        public Text city_bottom_text;
        public Button city_bottom_button;
        public Button city_bottom_upgrade_button;
        public Text city_bottom_upgrade_cost;

        public static ButtonListener _instance;

        public List<GameObject> buildings;
        public List<ShopUpgradeObject> upgrades;

        public Button adsOpen;
        public Button adsExit;
        public GameObject adsPanel;

        

        GameObject choosedBall;

        public static int Lives
        {
            get => lives;
            set
            {
                lives = value;
                // _instance.lives_text.text = "" + value;
                if (value <= 0)
                {
                    var p = MoveCoordinator.P;
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

        

        

        void OnChooseBall(GameObject ball)
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart
                && GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;
            if (choosedBall != null)
                choosedBall.transform.GetChild(0).gameObject.SetActive(false);


            choosedBall = ball;
            ball.transform.GetChild(0).gameObject.SetActive(true);
        }

        void OnShop()
        {
            PanelManager.Get().shop_panel.SetActive(!PanelManager.Get().shop_panel.activeSelf);
        }

        void OnShopExit()
        {
            PanelManager.Get().shop_panel.SetActive(false);
        }

       



        public static void ResetStats()
        {

        }

        
        private static int lives;
      
       
    }
}
