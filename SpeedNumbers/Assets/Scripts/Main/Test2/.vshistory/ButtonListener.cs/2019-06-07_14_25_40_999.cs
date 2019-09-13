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

        public Button BetUp;
        public Button BetDown;
        public Text BetText;

        private static ButtonListener _instance;
        void Start()
        {
            PlayButton.onClick.AddListener(OnPlayButton);
            
            PauseButton.onClick.AddListener(OnPauseButton);
            BetUp.onClick.AddListener(OnBetUp);
            BetDown.onClick.AddListener(OnBetDown);
            _instance = this;
        }

        public static void OnPlayButton()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart) return;
            LineGenerator.ClearLines();
            MoveCoordinator.P = 0;
            GameCoordinator.UpdateState(GameCoordinator.GameStates.Moving);
            PlayerManager.Round++;
        }

        public static void OnBetUp()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart) return;
            var max = 5;
            var lastBet = PlayerManager.BetNumber;
            if (lastBet + 1 > max) return;
            PlayerManager.BetNumber++;
            _instance.BetText.text = PlayerManager.BetNumber + "";
        }

        public static void OnBetDown()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart) return;
            if (PlayerManager.BetNumber - 1 < 0) return;
            PlayerManager.BetNumber--;
            _instance.BetText.text = PlayerManager.BetNumber + "";
        }

        public static void OnPauseButton()
        {
            PauseMenuManager.OpenPause(false);
        }
    }
}
