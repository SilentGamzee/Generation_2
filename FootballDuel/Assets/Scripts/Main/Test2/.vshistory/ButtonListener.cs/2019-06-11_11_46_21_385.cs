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
        public Button PlayButton;
        public Button PauseButton;


        private static ButtonListener _instance;
        void Start()
        {
            PlayButton.onClick.AddListener(OnPlayButton);
            
            PauseButton.onClick.AddListener(OnPauseButton);
           
             _instance = this;
        }


     

        public static void OnPlayButton()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart) {
                if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;
                MoveCoordinator.P ++;
            }
            
            MoveCoordinator.P = 0;
            GameCoordinator.UpdateState(GameCoordinator.GameStates.Moving);
            PlayerManager.Round++;
        }

       
        

        public static void OnPauseButton()
        {
            PauseMenuManager.OpenPause(false);
        }
    }
}
