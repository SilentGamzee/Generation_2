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
        public Text pointsText;
        public Text roundText;

        private static int points;
        public static int round;

        private static PlayerManager _instance;

        public static int Points
        {
            get => points;
            set
            {
                points = value;
                
            }
        }


        void Start()
        {
            _instance = this;
        }

        public static void Lose()
        {
            points -= _instance.pointsLose;
        }

        public static void Win(int extraPoints)
        {
            points += _instance.pointsWin + extraPoints;
        }
    }
}
