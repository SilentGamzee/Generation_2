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
                _instance.pointsText.text = "" + value;
                SaveInfo.OnSave();
            }
        }

        public static int player_speed_lvl = 0;
        public static int player_switch_lvl = 0;
        public static int player_training_lvl = 0;

        public static int P
        {
            get => p;
            set
            {
                p = value;
            }
        }
        private static int p = 0;

        void Awake()
        {
            _instance = this;
        }

    }
}
