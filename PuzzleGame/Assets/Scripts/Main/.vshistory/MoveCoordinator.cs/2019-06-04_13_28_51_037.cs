using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        }

        private static void ResetPosition(GameObject _item, bool isRow)
        {
            var temp = _item.transform.position;
            if (isRow)
                temp.x = start_x;
            else
                temp.y = start_y;
            _item.transform.position = temp;
        }

        private static void UpdatePosition(GameObject _item, bool IsRow)
        {
            int lastPos;
            if (IsRow)
                lastPos = objPoints_x[_item];
            else
                lastPos = objPoints_y[_item];

            if (lastPos == 0)
            {
                ResetPosition(_item, IsRow);
                InitScript.UpdateImage(_item);
                if (IsRow)
                    objPoints_x[_item] = x_points.Count - 1;
                else
                    objPoints_y[_item] = y_points.Count - 1;
                return;
            }
            if (IsRow)
            {
                if (!objPoints_x.ContainsValue(lastPos - 1))
                    objPoints_x[_item] = lastPos - 1;
            }
            else
                if (!objPoints_y.ContainsValue(lastPos - 1))
                objPoints_y[_item] = lastPos - 1;
        }



        void UpdateColRow(Transform trans, float step, bool isRow)
        {
            for (var i = 0; i < trans.childCount; i++)
            {
                var item = trans.GetChild(i);
                float move;
                if (isRow)
                    move = x_points[objPoints_x[item.gameObject]];
                else
                    move = y_points[objPoints_y[item.gameObject]];
                var r_pos = item.position;
                if (isRow)
                    item.position = Vector3.MoveTowards(r_pos, new Vector3(move, r_pos.y, r_pos.z), step);
                else
                    item.position = Vector3.MoveTowards(r_pos, new Vector3(r_pos.x, move, r_pos.z), step);

                float orig_pos;
                if (isRow)
                    orig_pos = r_pos.x;
                else
                    orig_pos = r_pos.y;

                if (Math.Abs(orig_pos - move) <= 0.1f)
                {
                    if (t < TimeDelay)
                        UpdatePosition(item.gameObject, isRow);
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
            UpdateColRow(trans_col, step, false);
            UpdateColRow(trans_row, step, true);

            if (isRowMovingDown)
            {
                trans_row.position = Vector3.MoveTowards(trans_row.position, new Vector3(trans_row.position.x, row_bottom_y, trans_row.position.z), step);
            }
            else
            {
                trans_row.position = Vector3.MoveTowards(trans_row.position, new Vector3(trans_row.position.x, row_bottom_y, trans_row.position.z), step);

            }
        }
    }
}
