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

        public GameObject shop_panel;
        public GameObject city_panel;
        public GameObject playground_panel;
        public GameObject city_bottom_panel;

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

        public List<Button> hard_modes_buttons;

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
                    isGameEnd = true;
                }
            }
        }
        public static int Lives_max = 3;
        private static GameObject lastChoosed;
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
            shop_panel.SetActive(!shop_panel.activeSelf);
        }

        void OnShopExit()
        {
            shop_panel.SetActive(false);
        }

       



        public static void ResetStats()
        {

        }

        private float t = 0;
        private static int lives;
        private static bool isGameEnd = false;
        void Update()
        {


            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart) return;
            if (isGameEnd)
            {
                t += Time.deltaTime;
                if (t >= 0.3f && t <= 0.4f)
                    MoveCoordinator.ResetPosition();
                if (t < 1.5f) return;
                t = 0;
                isGameEnd = false;
                ButtonListener._instance.city_panel.SetActive(true);
                ButtonListener._instance.playground_panel.SetActive(false);

                GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
            }

            /*
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - arrow.transform.position;
            diff.Normalize();


            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            var euler = Quaternion.Euler(0f, 0f, rot_z - 90);
            if (Math.Abs(euler.z) <= 0.5f)
                arrow.transform.rotation = euler;
                */
        }
    }
}
