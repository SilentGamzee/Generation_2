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
        public Button PlayButton;
        public Button PauseButton;
        public Button StartButton;
        public Button shopButton;
        public Button shop_exit_button;
        public Button tier1_button;
        public Button tier2_button;
        public Button tier3_button;

        public Transform top;
        public Transform bottom;

        public GameObject arrow;

        public Text lives_text;

        public GameObject shop_panel;

        public static ButtonListener _instance;

        int tier1_cost = 10;
        int tier2_cost = 100;
        int tier3_cost = 1000;

        public static int Lives
        {
            get => lives;
            set
            {
                lives = value;
                _instance.lives_text.text = "" + value;
                if (value <= 0)
                {
                    GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);
                }
            }
        }
        public static int Lives_max = 3;

        void Start()
        {
            _instance = this;

            Lives = 3;
            StartButton.onClick.AddListener(OnStartButton);
            shopButton.onClick.AddListener(OnShop);
            shop_exit_button.onClick.AddListener(OnShopExit);
            tier1_button.onClick.AddListener(OnTier1);
            tier2_button.onClick.AddListener(OnTier2);
            tier3_button.onClick.AddListener(OnTier3);
            shop_panel.SetActive(false);
        }

        void OnTier1()
        {
            tier1_button.gameObject.SetActive(false);
        }

        void OnTier2()
        {
            tier2_button.gameObject.SetActive(false);
        }

        void OnTier3()
        {
            if()
            tier3_button.gameObject.SetActive(false);
        }

        void OnShop()
        {
            shop_panel.SetActive(!shop_panel.activeSelf);
        }

        void OnShopExit()
        {
            shop_panel.SetActive(false);
        }

        public static void OnStartButton()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart || lives <= 0) return;

            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _instance.arrow.transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            if (Math.Abs(Quaternion.Euler(0f, 0f, rot_z - 90).z) > 0.5f) return;

            PlayerManager.Round++;
            var trans_col = InitScript._instance.randomCol.transform;
            var item = trans_col.GetChild(1);
            item.GetComponent<Rigidbody2D>().simulated = true;



            GameCoordinator.UpdateState(GameCoordinator.GameStates.Moving);



            var rb2D = item.GetComponent<Rigidbody2D>();
            rb2D.AddForce(diff * 0.8f);

        }



        public static void ResetStats()
        {

        }

        private float t = 0;
        private static float avgHeightValue1;
        private static int extra_jump1;
        private static int lives;

        void Update()
        {


            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart
                && GameCoordinator.GetGameState() != GameCoordinator.GameStates.GameEnd) return;


            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - arrow.transform.position;
            diff.Normalize();


            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            var euler = Quaternion.Euler(0f, 0f, rot_z - 90);
            if (Math.Abs(euler.z) <= 0.5f)
                arrow.transform.rotation = euler;
        }
    }
}
