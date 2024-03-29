﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main
{
    class ButtonListener : MonoBehaviour
    {
        public Button PlayButton;
        public Button PauseButton;
        public Button StartButton;

        public Transform top;
        public Transform bottom;

        public static ButtonListener _instance;
 

        void Start()
        {
            _instance = this;
         
            StartButton.onClick.AddListener(OnStartButton);

        }

        public static void OnStartButton()
        {
            //if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart) return;
            

            PlayerManager.Round++;
            var trans_col = InitScript._instance.randomCol.transform;
            var item = trans_col.GetChild(0);
            item.GetComponent<Rigidbody2D>().simulated = true;

            GameCoordinator.UpdateState(GameCoordinator.GameStates.Moving);

            MoveCoordinator.P++;
            MoveCoordinator.AddForceToBall();
            
        }

       

        public static void ResetStats()
        {
        
        }

        private float t = 0;
        private static float avgHeightValue1;

        void Update()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;

            var pos = Input.mousePosition;

            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
    }
}
