﻿using Assets.Scripts.Main.Test5.T1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main
{
    class MoveCoordinator : MonoBehaviour
    {
        //PUBLIC EDITOR
        public float MoveSpeed;
        public float TimeDelay;
  
        public GameObject ball;


        //PRIVATE STATIC
        public static MoveCoordinator _instance;


       


        private static float t = 0;
        private static int p = 0;
        private static int e_p = 0;

        void Awake()
        {
            _instance = this;
        }


        public static Dictionary<GameObject, Vector3> start_pos_dict = new Dictionary<GameObject, Vector3>();

        public static void Init()
        {

            
        }

        public static void ResetPosition()
        {
            foreach (var kv in start_pos_dict)
            {
                var item = kv.Key;
                var pos = kv.Value;
                item.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                item.transform.position = pos;
            }
        }

        private static void AddForce(GameObject ball, float up, float right, float left)
        {
            var trans = ball.transform;
            var rb2D = ball.GetComponent<Rigidbody2D>();
            if (up > 0)
                rb2D.AddForce(trans.up * up);
            if (right > 0 && rb2D.velocity.y != 0)
                rb2D.AddForce(trans.right * right);
            if (left > 0 && rb2D.velocity.y != 0)
                rb2D.AddForce(-trans.right * left);
        }

        public static void AddForceToBall(GameObject ball) => AddForce(ball, 0.01f, 0, 0);

        public static void AddForceToBallBottom(GameObject ball) => AddForce(ball, -0.01f, 0, 0);

        public static void AddForceToBallLight(GameObject ball) => AddForce(ball, 0.01f, 0, 0);

        public static void AddForceToBallLeft(GameObject ball) => AddForce(ball, 0.00f, 0, 0.01f);

        public static void AddForceToBallRight(GameObject ball) => AddForce(ball, 0.00f, 0.01f, 0);


        void DoArtificalMove()
        {
            if (ButtonListener.isGameEnd) return;
            var enemy = ButtonListener._instance.enemy_hero;
            var ball = ButtonListener._instance.ball;
            var target = enemy.transform.position;
            target.y = ball.transform.position.y;
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target, Time.deltaTime);
        }

        void Update()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;

            t += Time.deltaTime;
            if (t < 2f) return;
            t = 0;
            DoArtificalMove();
            GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
        }
    }
}
