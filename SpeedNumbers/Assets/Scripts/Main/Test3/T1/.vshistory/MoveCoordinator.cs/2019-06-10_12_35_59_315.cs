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
    class MoveCoordinator : MonoBehaviour
    {
        //PUBLIC EDITOR
        public float MoveSpeed;
        public float TimeDelay;
        public Text pointsVorotaText;
        public GameObject left;
        public GameObject right;

        //PRIVATE STATIC
        private static MoveCoordinator _instance;
        private static List<Vector3> points = new List<Vector3>();
        private static Vector3 nextPoint;



        private static Vector3 start_pos;

        public static int P
        {
            get => p;
            set
            {
                p = value;
                _instance.pointsVorotaText.text = "Goal: " + value;
            }
        }

        private static float t = 0;
        private static int p = 0;

        void Awake()
        {
            _instance = this;
        }

        public static void Init()
        {
            var trans_col = InitScript._instance.randomCol.transform;
            for (var i = 0; i < trans_col.childCount; i++)
            {
                var item = trans_col.GetChild(i);
                var pos = item.transform.position;
                
            }

            var trans_row = InitScript._instance.randomRow.transform;
            for (var i = 0; i < trans_row.childCount; i++)
            {
                var item = trans_row.GetChild(i);
                var pos = item.transform.position;
                points.Add(pos);
            }



            start_pos = trans_row.GetChild(0).position;

        }

        private static void ResetPosition()
        {
            var trans_r = InitScript._instance.randomRow.transform;
            for (var i = 0; i < trans_r.childCount; i++)
            {
                var item = trans_r.GetChild(i);
                item.transform.position = start_pos;
            }
        }

        private static void UpdatePosition(GameObject ball, int i)
        {
            /*
            if (nextPoint != start_pos)
                nextPoint = start_pos;
            else
            {
                var r = UnityEngine.Random.Range(0, points.Count - 1);
                nextPoint = points[r];
            }
            */
            ball.transform.position = points[i];
        }

        void UpdateBallPos(Transform trans, float step)
        {
            
            var vorota_pos = InitScript._instance.randomCol.transform.GetChild(0).position;
            for (var i = 0; i < trans.childCount; i++)
            {
                var item_step = step * UnityEngine.Random.Range(0.1f, 2f);

                var item = trans.GetChild(i);

                var r_pos = item.position;
                var next_point = new Vector3(r_pos.x, vorota_pos.y, r_pos.z);
                item.position = Vector3.MoveTowards(r_pos, next_point, item_step);

                if ((Math.Abs(r_pos.y - next_point.y) <= 0.3f))
                {
                    if (Math.Abs(r_pos.x - vorota_pos.x) <= 0.5f)
                        P++;

                    if (t < TimeDelay)
                        UpdatePosition(item.gameObject, i);
                    else
                    {
                        ResetPosition();
                        GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);
                    }
                }
            }
        }

        private static bool IsMovingLeft = false;
        void UodateVorotaPos(Transform vorota, float step)
        {
            Vector3 m_pos;
            if (IsMovingLeft)
                m_pos = _instance.left.transform.position;
            else
                m_pos = _instance.right.transform.position;

            vorota.position = Vector3.MoveTowards(vorota.position, m_pos, step);

            if (Math.Abs(vorota.position.x - m_pos.x) <= 0.01f)
                IsMovingLeft = !IsMovingLeft;
        }


        void Update()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving)
            {
                if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Pause)
                {
                    t = 0;
                    PlayerManager.UpdateRoundProgress(t / TimeDelay * 100);
                }
                return;
            }
            t += Time.deltaTime;
            PlayerManager.UpdateRoundProgress(t / TimeDelay * 100);

            float param = Mathf.InverseLerp(0, 1, TimeDelay / t / 5f);

            float step = MoveSpeed 
                //* param 
                * Time.deltaTime;
            var trans_col = InitScript._instance.randomCol.transform;
            var trans_row = InitScript._instance.randomRow.transform;

            UpdateBallPos(trans_row, step);

            UodateVorotaPos(trans_col.GetChild(0), step);
        }
    }
}
