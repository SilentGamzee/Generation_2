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
        public GameObject row_top;
        public GameObject row_bottom;
        public GameObject col_left;
        public GameObject col_right;

        //PRIVATE STATIC
        private static MoveCoordinator _instance;
        private static List<float> y_points = new List<float>();
        private static List<float> x_points = new List<float>();
        private static float start_y;
        private static float start_x;
        private static float col_left_x;
        private static float col_right_x;
        private static float row_top_y;
        private static float row_bottom_y;

        private static bool isRowMovingDown = false;
        private static bool isColMovingLeft = false;

        //PUBLIC STATIC
        public static Dictionary<GameObject, int> objPoints_y = new Dictionary<GameObject, int>();
        public static Dictionary<GameObject, int> objPoints_x = new Dictionary<GameObject, int>();

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
                var y_pos = item.transform.position.y;
                y_points.Add(y_pos);
                if (i == 0)
                {
                    Destroy(item.gameObject);
                    continue;
                }
                objPoints_y.Add(item.gameObject, i);
            }

            var trans_row = InitScript._instance.randomRow.transform;
            for (var i = 0; i < trans_row.childCount; i++)
            {
                var item = trans_row.GetChild(i);
                var x_pos = item.transform.position.x;
                x_points.Add(x_pos);
                if (i == 0)
                {
                    Destroy(item.gameObject);
                    continue;
                }
                objPoints_x.Add(item.gameObject, i);
            }

            start_y = trans_col.GetChild(trans_col.childCount - 1).position.y;
            start_x = trans_row.GetChild(trans_row.childCount - 1).position.x;

            col_left_x = _instance.col_left.transform.position.x;
            col_right_x = _instance.col_right.transform.position.x;

            row_top_y = _instance.row_top.transform.position.y;
            row_bottom_y = _instance.row_bottom.transform.position.y;
        }




        private static void ResetPosition()
        {
            var trans = InitScript._instance.randomCol.transform;
            for (var i = 0; i < trans.childCount; i++)
            {
                var item = trans.GetChild(i);
                var temp = item.transform.position;
                temp.y = y_points[objPoints_y[item.gameObject]];
                item.transform.position = temp;
            }

            var trans_r = InitScript._instance.randomRow.transform;
            for (var i = 0; i < trans_r.childCount; i++)
            {
                var item = trans_r.GetChild(i);
                var temp = item.transform.position;
                temp.x = x_points[objPoints_x[item.gameObject]];
                item.transform.position = temp;
            }

            var temp_col = InitScript._instance.randomCol.transform.position;
            temp_col.x = 0;
            InitScript._instance.randomCol.transform.position = temp_col;

            var temp_row = InitScript._instance.randomCol.transform.position;
            temp_row.y = 0;
            InitScript._instance.randomRow.transform.position = temp_row;
        }

        private static void ResetPosition(GameObject _item)
        {
            var temp = _item.transform.position;

            temp.x = start_x;

            _item.transform.position = temp;


        }

        private static void UpdatePosition(GameObject _item)
        {
            int lastPos;

            lastPos = objPoints_x[_item];


            if (lastPos == 0)
            {
                ResetPosition(_item);
                InitScript.UpdateImage(_item);

                objPoints_x[_item] = x_points.Count - 1;

                return;
            }

            if (!objPoints_x.ContainsValue(lastPos - 1))
                objPoints_x[_item] = lastPos - 1;

        }



        void UpdateColRow(Transform trans, float step)
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

        void UpdateRowColPos(Transform trans, float param)
        {
            float row_step = MoveSpeed * param * Time.deltaTime * 0.6f;
            float row_pos;

            if (isRowMovingDown)
                row_pos = row_bottom_y;
            else
                row_pos = row_top_y;
            row_pos = col_right_x;



            trans.position = Vector3.MoveTowards(trans.position, new Vector3(trans.position.x, row_pos, trans.position.z), row_step);
            if (Math.Abs(trans.position.y - row_pos) <= 0.1f)
                isRowMovingDown = !isRowMovingDown;


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

            UpdateColRow(trans_row, step, true);


            UpdateRowColPos(trans_row, param, true);

        }
    }
}
