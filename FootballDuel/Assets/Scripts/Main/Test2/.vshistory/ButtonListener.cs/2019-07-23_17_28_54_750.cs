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

        public static int Lives
        {
            get => lives;
            set
            {
                lives = value;
                _instance.myHp_text.text = value + "/" + Lives_max;
                _instance.myHp_progress.fillAmount = value / (float)Lives_max;
                if (value <= 0)
                {

                    lives = Lives_max;
                    isGameEnd = true;
                }
            }
        }
        public static int Lives_max = 3;

        public static int LivesEnemy
        {
            get => lives;
            set
            {
                lives = value;
                _instance.enemyHp_text.text = value + "/" + Lives_max_enemy;

                _instance.enemyHp_progress.fillAmount = value / (float)Lives_max_enemy;
                if (value <= 0)
                {

                    lives = Lives_max_enemy;
                    isGameEnd = true;
                }
            }
        }
        public static int Lives_max_enemy = 3;



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
            rb2D.AddForce(diff * 0.8f * (PlayerManager.player_ball_speed_lvl * 0.001f));
        }



        public static void ResetStats()
        {

        }

        private float t = 0;
        private static int lives;
        private static bool isGameEnd = false;
        void Update()
        {


            if (isGameEnd && GameCoordinator.GetGameState() == GameCoordinator.GameStates.WaitingToStart)
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
