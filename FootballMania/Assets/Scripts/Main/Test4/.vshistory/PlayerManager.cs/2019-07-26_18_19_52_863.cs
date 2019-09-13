using Assets.Scripts.Main.Test2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main
{
    class PlayerManager:MonoBehaviour
    {
        
        public int pointsWin;
        public int pointsLose;

        public Image pointsProgress;
        public Text pointsText;
        public Image roundProgress;
        public Text roundText;
       

        private static int points;
        private static int round;
        private static bool prestart = true;

        private static PlayerManager _instance;

        private static bool isStandart = true;
        public static hardmodes HardMode;
        public enum hardmodes
        {
            Easy,
            Normal,
            Hard
        } 

        public static int Points
        {
            get => points;
            set
            {
                points = value;
                
               // UpdatePointsProgress(value/500f);
                _instance.pointsText.text = ""+ value;
                PlayerPrefs.SetInt("money", value);
            }
        }

        public static int Round
        {
            get => round;
            set
            {
                round = value;
              //  _instance.roundText.text = "Round: " + value;
            }
        }

        public static bool IsStandart { get => isStandart;
            set
            {
                isStandart = value;
                if (value)
                    GameModeListener.OnStandart();
                else
                    GameModeListener.OnPoints();
            }
        }

        public static int BetNumber = 0;

        void Start()
        {
            _instance = this;
            Points = 0;
            Round = 0;
            if (PlayerPrefs.HasKey("money"))
                Points = PlayerPrefs.GetInt("money");
        }

        public static void Reset()
        {
            Points = 0;
            Round = 0;
        }

        public static void Lose()
        {
            prestart = false;
            Points -= _instance.pointsLose;
            if (!IsEnoughPoints())
                PauseMenuManager.OpenPause(true);

            
        }

        public static void Win()
        {
            prestart = false;
            Points += _instance.pointsWin;
          
        }

        public static bool IsEnoughPoints()
        {
            return Points >= _instance.pointsLose;
        }


        public static void UpdateRoundProgress(float procent)
        {
            _instance.roundProgress.fillAmount = procent / 100f;
        }

        private static void UpdatePointsProgress(float procent)
        {
            _instance.pointsProgress.fillAmount = procent;
        }
        

        void Update()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart
                || GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart)
            {
              
                return;
            }
            
        }
    }
}
