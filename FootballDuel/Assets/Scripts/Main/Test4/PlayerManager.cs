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
        public Text exp_Text;
        public Text shop_points;
        public Image exp_progress;


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

                _instance.pointsText.text = "" + value;
                _instance.shop_points.text = "" + value;
                SaveInfo.OnSave();
            }
        }

        public static int level { get => level1;
            set {
                level1 = value;
                _instance.exp_Text.text = value + " level";
            }
        }
        public static int EXP
        {
            get => eXP;
            set
            {
                eXP = value;
                if (eXP >= 100)
                {
                    level++;
                    eXP = 0;
                }
                _instance.exp_progress.fillAmount = eXP / 100f;
                SaveInfo.OnSave();
            }
        }

        public static int player_speed_lvl = 0;
        public static int player_ball_speed_lvl = 0;
        public static int player_ball_damage_lvl = 0;

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
