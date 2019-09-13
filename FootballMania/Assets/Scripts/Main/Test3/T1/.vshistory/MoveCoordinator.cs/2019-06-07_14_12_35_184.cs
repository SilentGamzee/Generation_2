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
        public Text pointsVorotaText;

        //PRIVATE STATIC
        private static MoveCoordinator _instance;
        private static List<Vector3> points = new List<Vector3>();
        private static Vector3 nextPoint;

        private static List<Vector3> vorotaPoints = new List<Vector3>();

        private static Vector3 start_pos;

        public static int P
        {
            get => p;
            set
            {
                p = value;
                _instance.pointsVorotaText.text = "Goal: "+value;
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
                points.Add(pos);

                if(i<=1)
                    vorotaPoints.Add(pos);
            }

            var trans_row = InitScript._instance.randomRow.transform;
            for (var i = 0; i < trans_row.childCount; i++)
            {
                var item = trans_row.GetChild(i);
                var pos = item.transform.position;
                points.Add(pos);
            }

            

            start_pos = trans_row.GetChild(0).position;

            UpdatePosition();
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


        private static void UpdatePosition()
        {
            if (nextPoint != start_pos)
                nextPoint = start_pos;
            else
            {
                var r = UnityEngine.Random.Range(0, points.Count - 1);
                nextPoint = points[r];
            }
        }



        void UpdateBallPos(Transform trans, float step)
        {
            for (var i = 0; i < trans.childCount; i++)
            {
                var item = trans.GetChild(i);

                var r_pos = item.position;

                item.position = Vector3.MoveTowards(r_pos, nextPoint, step);

                if ((Math.Abs(r_pos.x - nextPoint.x) <= 0.3f) && (Math.Abs(r_pos.y - nextPoint.y) <= 0.3f))
                {
                    if (vorotaPoints.Contains(nextPoint))
                        P++;

                    if (t < TimeDelay)
                        UpdatePosition();
                    else
                    {
                        ResetPosition();
                        GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);
                    }
                }
            }
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

            float step = MoveSpeed * param * Time.deltaTime;
            var trans_col = InitScript._instance.randomCol.transform;
            var trans_row = InitScript._instance.randomRow.transform;

            UpdateBallPos(trans_row, step);



        }
    }
}
