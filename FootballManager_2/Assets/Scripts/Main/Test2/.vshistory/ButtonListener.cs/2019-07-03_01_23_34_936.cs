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


        public Text lastClickTime;
        public Text avgLastClickTime;
        public Text topDist;
        public Text bottomDist;

        private static float lastClick { get => lastClick1; set
            {
                lastClick1 = value;
                _instance
            }
        }
        public static ButtonListener _instance;
        private static float lastClick1;

        void Start()
        {
            _instance = this;
            PauseButton.onClick.AddListener(OnPauseButton);
            StartButton.onClick.AddListener(OnStartButton);
           
        }

        public static void OnStartButton()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart
                && GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;

            if (GameCoordinator.GetGameState() == GameCoordinator.GameStates.WaitingToStart)
            {
                MoveCoordinator.P = 0;

                PlayerManager.Round++;
                var trans_col = InitScript._instance.randomCol.transform;
                var item = trans_col.GetChild(0);
                item.GetComponent<Rigidbody2D>().simulated = true;

                GameCoordinator.UpdateState(GameCoordinator.GameStates.Moving);
            }
            lastClick = 0;
            MoveCoordinator.P++;
            MoveCoordinator.AddForceToBall();
        }

        public static void OnPauseButton()
        {
            PauseMenuManager.OpenPause(false);
        }

        void Update()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;
            lastClick += Time.deltaTime;

        }
    }
}
