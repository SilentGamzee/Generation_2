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

        private static ButtonListener _instance;
        void Start()
        {
            PlayButton.onClick.AddListener(OnPlayButton);
            


            PauseButton.onClick.AddListener(OnPauseButton);
            StartButton.onClick.AddListener(OnStartButton);
              _instance = this;
        }

        public static void OnStartButton()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart)
            {
            }
        

        public static void OnPlayButton()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart) {
                if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;
                MoveCoordinator.P ++;
                MoveCoordinator.AddForceToBall();
                return;
            }
            
            MoveCoordinator.P = 1;
            GameCoordinator.UpdateState(GameCoordinator.GameStates.Moving);
            PlayerManager.Round++;

            var trans_col = InitScript._instance.randomCol.transform;
            var item = trans_col.GetChild(0);
            item.GetComponent<Rigidbody2D>().simulated = true;
            MoveCoordinator.AddForceToBall();
        }

       
        

        public static void OnPauseButton()
        {
            PauseMenuManager.OpenPause(false);
        }
    }
}
