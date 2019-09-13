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
        public GameObject row_top;
        public GameObject row_bottom;
        public GameObject col_left;
        public GameObject col_right;

        //PRIVATE STATIC
        private static MoveCoordinator _instance;
        private static List<float> y_points = new List<float>();
        private static List<float> x_points = new List<float>();
        
        private static float start_y;
       

        //PUBLIC STATIC
        public static Dictionary<GameObject, int> objPoints_y = new Dictionary<GameObject, int>();
        public static Dictionary<GameObject, int> objPoints_x = new Dictionary<GameObject, int>();
        public static Dictionary<GameObject, int> start_x_points = new Dictionary<GameObject, int>();

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
                var y_pos = item.transform.position.y;
                y_points.Add(y_pos);
               
                objPoints_y.Add(item.gameObject, i);
            }

            var trans_row = InitScript._instance.randomRow.transform;
            for (var i = 0; i < trans_row.childCount; i++)
            {
                var item = trans_row.GetChild(i);
                var x_pos = item.transform.position.x;
                x_points.Add(x_pos);
                start_x_points.Add(item.gameObject, i);
                objPoints_x.Add(item.gameObject, i);
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

      
        void UpdateColPos()
        {
            var trans_r = InitScript._instance.randomCol.transform;
            var item = trans_r.GetChild(0);
            var movePoint = trans_r.GetChild(1).transform.position;
            var pos = item.position;
            float step = MoveSpeed  * Time.deltaTime;
            if (IsMovingDown)
            {
                item.position = Vector3.MoveTowards(pos, new Vector3(pos.x, start_y, pos.z), step);
            }
            else
                item.position = Vector3.MoveTowards(pos, new Vector3(pos.x, movePoint.y, pos.z), step);
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

            UpdateColRow(trans_row, step);
            UpdateColPos(step);


        }
    }
}
