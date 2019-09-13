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

        public Image pointsProgress;
        public Text pointsText;
        public Image roundProgress;
        public Text roundText;
        public Text winText;

        private static int points;
        private static int round;

        private static PlayerManager _instance;

        public static int Points
        {
            get => points;
            set
            {
                points = value;
                Debug.Log(value / 10000f);
                UpdatePointsProgress(value/10000f);
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
            Round = 0;
        }

        public static void Reset()
        {
            Points = _instance.startPoints;
            Round = 0;
        }

        public static void Lose()
        {
            Points -= _instance.pointsLose;
            if (!IsEnoughPoints())
                PauseMenuManager.OpenPause(true);

            _instance.winText.text = "LOSE";
        }

        public static void Win()
        {
            Points += _instance.pointsWin;
            _instance.winText.text = "WIN";
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
                winText.gameObject.SetActive(false);
                return;
            }
        }
    }
}
