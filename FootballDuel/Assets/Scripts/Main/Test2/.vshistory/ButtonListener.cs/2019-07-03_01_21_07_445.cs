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


        public static ButtonListener _instance;
        void Start()
        {




            PauseButton.onClick.AddListener(OnPauseButton);
            StartButton.onClick.AddListener(OnStartButton);
            _instance = this;
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

            MoveCoordinator.P++;
            MoveCoordinator.AddForceToBall();

        }






        public static void OnPauseButton()
        {
            PauseMenuManager.OpenPause(false);
        }
    }
}
