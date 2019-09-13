using Assets.Scripts.Main.Test6;
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




        private static int points;


        public static PlayerManager _instance;

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

                SaveInfo.OnSave();

                _instance.pointsText.text = "" + value;
            }
        }



        public static int player_speed_lvl = 0;
        public static int player_switch_lvl = 0;
        public static int player_training_lvl = 0;

        public static int BetNumber = 0;
        private static int eXP;
        private static int level1 = 1;

        void Awake()
        {
            _instance = this;
        }

        public static void Reset()
        {
            Points = 0;

        }

        public static void Lose()
        {
            Points -= _instance.pointsLose;
            if (!IsEnoughPoints())
                PauseMenuManager.OpenPause(true);
        }

        public static void Win()
        {
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
