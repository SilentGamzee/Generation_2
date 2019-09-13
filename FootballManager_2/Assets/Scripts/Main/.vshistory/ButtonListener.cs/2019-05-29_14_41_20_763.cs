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
        public Button ResetButton;
        public Button PauseButton;

        void Start()
        {
            PlayButton.onClick.AddListener(OnPlayButton);
            ResetButton.onClick.AddListener(OnResetButton);
            PauseButton.onClick.AddListener(OnPauseButton);
        }

        public static void OnPlayButton()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart) return;
            MoveCoordinator.Reset();
            GameCoordinator.UpdateState(GameCoordinator.GameStates.Randoming);
        }

        public static void OnResetButton()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.GameEnd) return;
            InitScript.ResetMatrix();
            PreEndCalculator.Reset();
        }

        public static void OnPauseButton()
        {

        }
    }
}
