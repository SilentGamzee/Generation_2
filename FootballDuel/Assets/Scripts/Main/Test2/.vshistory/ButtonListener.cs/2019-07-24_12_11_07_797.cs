using Assets.Scripts.Main.Test3;
using Assets.Scripts.Main.Test5.T1;
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
        public GameObject arrow;
        public GameObject ball;
        public GameObject myhero;
        public GameObject enemy_hero;
        public Button PauseButton;
        public Button StartButton;




        public Transform top;
        public Transform bottom;

        public GameObject shop_panel;
        public GameObject city_panel;
        public GameObject playground_panel;
        public GameObject city_bottom_panel;

        public Text city_bottom_text;
        public Button city_bottom_button;

        public static ButtonListener _instance;

        public List<GameObject> buildings;
        public List<ShopUpgradeObject> upgrades;

        public Text myHp_text;
        public Text enemyHp_text;
        public Image myHp_progress;
        public Image enemyHp_progress;
        public GameObject button_panel;

        public GameObject gameEndPanel;
        public Button gameEndButton;
        public Text gameEndWinText;
        public Text gameEndGoldText;
        public Text gameEndExpText;

        public static int Lives
        {
            get => lives;
            set
            {
                if (value < 0)
                    value = 0;
                lives = value;
                UpdateHpBars();
                if (value <= 0)
                {
                    lives = Lives_max;
                    isGameEnd = true;
                    OnGameEnd(false);
                }
            }
        }
        public static int Lives_max = 3;

        public static int LivesEnemy
        {
            get => lives_enemy;
            set
            {
                if (value < 0)
                    value = 0;
                lives_enemy = value;
                UpdateHpBars();
                if (value <= 0)
                {
                    PlayerManager.Points += 100;
                    PlayerManager.EXP += 30;
                    ButtonListener.Lives_max_enemy++;
                    lives_enemy = Lives_max_enemy;
                    isGameEnd = true;
                    OnGameEnd(true);
                }
            }
        }
        public static int Lives_max_enemy = 3;


        public static void UpdateHpBars()
        {
            _instance.myHp_text.text = lives + "/" + Lives_max;
            _instance.myHp_progress.fillAmount = lives / (float)Lives_max;

            _instance.enemyHp_text.text = lives_enemy + "/" + Lives_max_enemy;
            _instance.enemyHp_progress.fillAmount = lives_enemy / (float)Lives_max_enemy;
        }

        private static GameObject lastChoosed;
        void Start()
        {
            _instance = this;

            SaveInfo.OnStart();

            Lives = Lives_max;
            StartButton.onClick.AddListener(OnStartButton);

            PauseButton.onClick.AddListener(MenuManager.OnReturn);



            foreach (var building in buildings)
            {
                var current = building;
                building.GetComponent<Button>().onClick.AddListener(delegate { OnChooseBuilding(current); });
            }

            city_bottom_button.onClick.AddListener(OnBuildingButton);

        }



        void OnChooseBuilding(GameObject building)
        {
            lastChoosed = building;
            button_panel.transform.SetParent(building.transform);
            var p = button_panel.transform.localPosition;
            p.x = 0;
            button_panel.transform.localPosition = p;
            building.GetComponent<BuildingObject>().OnChoose(city_bottom_text);
            city_bottom_panel.SetActive(true);
            Debug.Log("Choose: " + building);
        }

        void OnBuildingButton() => lastChoosed.GetComponent<BuildingObject>().OnButton();





        public static void OnShop()
        {
            _instance.shop_panel.SetActive(!_instance.shop_panel.activeSelf);
        }


        public static void OnStartButton()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart) return;


            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _instance.myhero.transform.position;
            diff.Normalize();

            GameCoordinator.UpdateState(GameCoordinator.GameStates.Moving);
            var item = Instantiate(_instance.ball, _instance.myhero.transform);
            item.AddComponent<BallCollider>().isAlly = true;
            var rb2D = item.GetComponent<Rigidbody2D>();
            rb2D.AddForce(diff * (0.8f + (PlayerManager.player_ball_speed_lvl * 0.001f)));
        }



        public static void ResetStats()
        {
        }

        public static void OnGameEnd(bool win)
        {
            MoveCoordinator.ResetPosition();
            if (win)
            {
                _instance.gameEndWinText.text = "Win";
                _instance.gameEndGoldText.text = "100";
                _instance.gameEndExpText.text = "+10 Exp";
            }
            else
            {
                _instance.gameEndWinText.text = "Lose";
                _instance.gameEndGoldText.text = "0";
                _instance.gameEndExpText.text = "+0 Exp";
            }
            
            
        }

        public static void OnGameEndButton()
        {
            isGameEnd = false;
            ButtonListener._instance.city_panel.SetActive(true);
            ButtonListener._instance.playground_panel.SetActive(false);

            GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
        }

        private float t = 0;
        private static int lives;
        private static int lives_enemy;
        public static bool isGameEnd = false;
        void Update()
        {

            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart
                && GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;

            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - arrow.transform.position;
            diff.Normalize();


            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            var euler = Quaternion.Euler(0f, 0f, rot_z - 90);

            arrow.transform.rotation = euler;

        }
    }
}
