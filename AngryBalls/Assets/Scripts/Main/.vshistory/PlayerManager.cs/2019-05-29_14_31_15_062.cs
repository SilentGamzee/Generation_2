using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main
{
    class PlayerManager:MonoBehaviour
    {
        public int pointsWin;
        public int pointsLose;

        private static int points;
        private static int round;

        private static PlayerManager _instance;
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
