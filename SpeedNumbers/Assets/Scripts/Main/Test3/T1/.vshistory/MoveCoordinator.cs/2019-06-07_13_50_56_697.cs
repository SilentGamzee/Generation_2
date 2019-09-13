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

        //PRIVATE STATIC
        private static MoveCoordinator _instance;
        private static List<Vector3> points = new List<Vector3>();
        private static Vector3 nextPoint;

        private static float start_pos;


        

        private static bool IsMovingDown = false;

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
                points.Add(pos);
            }

            var trans_row = InitScript._instance.randomRow.transform;
            for (var i = 0; i < trans_row.childCount; i++)
            {
                var item = trans_row.GetChild(i);
                var pos = item.transform.position;
                points.Add(pos);
            }


            start_y = trans_col.GetChild(0).position.y;


        }




        private static void ResetPosition()
        {
            var trans_r = InitScript._instance.randomRow.transform;
            for (var i = 0; i < trans_r.childCount; i++)
            {
                var item = trans_r.GetChild(i);
                var temp = item.transform.position;
                temp.x = x_points[start_x_points[item.gameObject]];
                item.transform.position = temp;
            }

            var trans_col = InitScript._instance.randomCol.transform;
            var item_col = trans_col.GetChild(0);
            var temp_col = item_col.position;
            temp_col.y = start_y;
            item_col.position = temp_col;
        }


        private static void UpdatePosition(GameObject _item)
        {
            int lastPos;

            lastPos = objPoints_x[_item];


            if (lastPos == 0)
            {

                InitScript.UpdateImage(_item);

                objPoints_x[_item] = x_points.Count - 1;

                return;
            }

            if (!objPoints_x.ContainsValue(lastPos - 1))
                objPoints_x[_item] = lastPos - 1;

        }



        void UpdateBallPos(Transform trans, float step)
        {
            for (var i = 0; i < trans.childCount; i++)
            {
                var item = trans.GetChild(i);
                float move;

                move = x_points[objPoints_x[item.gameObject]];

                var r_pos = item.position;

                item.position = Vector3.MoveTowards(r_pos, new Vector3(move, r_pos.y, r_pos.z), step);

                float orig_pos;

                orig_pos = r_pos.x;


                if (Math.Abs(orig_pos - move) <= 0.1f)
                {
                    if (t < TimeDelay)
                        UpdatePosition(item.gameObject);
                    else
                    {
                        ResetPosition();
                        GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);
                    }
                }
            }
        }


       

        private static float t = 0;
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

            float step = MoveSpeed * param * Time.deltaTime;
            var trans_col = InitScript._instance.randomCol.transform;
            var trans_row = InitScript._instance.randomRow.transform;

            UpdateBallPos(trans_row, step);
           


        }
    }
}
