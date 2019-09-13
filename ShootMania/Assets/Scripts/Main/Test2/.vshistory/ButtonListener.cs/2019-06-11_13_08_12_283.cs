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
            
                if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;
                MoveCoordinator.P ++;
                MoveCoordinator.AddForceToBall();
                
            
            
            
        }

       
        

        public static void OnPauseButton()
        {
            PauseMenuManager.OpenPause(false);
        }
    }
}
