﻿using System;
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
        public int startPoints;
        public int pointsWin;
        public int pointsLose;
        public Text pointsText;
        public Text roundText;

        private static int points;
        private static int round;

        private static PlayerManager _instance;

        public static int Points
        {
            get => points;
            set
            {
                points = value;
                _instance.pointsText.text = "Points: " + value;
            }
        }

        public static int Round
        {
            get => round;
            set
            {
                round = value;
                _instance.roundText.text = "Round: " + value;
            }
        }

        void Start()
        {
            _instance = this;
            Points = startPoints;
        }

        public static void Lose(int extraPoints)
        {
            Points -= _instance.pointsLose + extraPoints;
        }

        public static void Win(int extraPoints)
        {
            Points += _instance.pointsWin + extraPoints;
        }
    }
}
