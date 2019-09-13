using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main
{
    class PlayerManager : MonoBehaviour
    {

        public int pointsWin;
        public int pointsLose;

        public Text pointsText;
        public Text exp_Text;
        public Image exp_progress;


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

                _instance.pointsText.text = "" + value;
            }
        }

        public static int level = 1;
        public static int EXP
        {
            get => eXP;
            set
            {
                eXP = value;
                if(eXP>=100)
                {
                    level++;
                    _instance.exp_Text.text = level + " level";
                    eXP = 0;
                }
            }
        }



        public static int BetNumber = 0;
        private static int eXP;

        void Start()
        {
            _instance = this;
            Points = 0;


        }

        public static void Reset()
        {
            Points = 0;

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
