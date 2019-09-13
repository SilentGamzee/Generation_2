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

        //PRIVATE STATIC
        private static List<float> x_points = new List<float>();
        private static float move_x;
        private static float start_x;
        private static int x = 0;
        private static float delay = 0;
        private static int row_count = 0;

        public static void Init()
        {
            var trans = InitScript._instance.randomRow.transform;
            for (var i = 0; i < trans.childCount; i++)
            {
                var item = trans.GetChild(i);
                var x_pos = item.transform.position.x;
                x_points.Add(x_pos);
            }
            move_x = trans.GetChild(0).position.x;
            start_x = trans.GetChild(trans.childCount - 1).position.x;

            row_count = trans.childCount;
        }




        private static void ResetPosition()
        {
            var trans = InitScript._instance.randomRow.transform;
            for (var i = 0; i < trans.childCount; i++)
            {
                var item = trans.GetChild(i);
                var temp = item.transform.position;
                temp.x = x_points[i];
                item.transform.position = temp;
            }
        }

        private static void ResetPosition(GameObject _item)
        {
            var trans = InitScript._instance.randomRow.transform;
            for (var i = 0; i < trans.childCount; i++)
            {
                var item = trans.GetChild(i);
                if (item.name != _item.name) continue;
                var temp = item.transform.position;
                temp.x = x_points[i];
                _item.transform.position = temp;
                Debug.Log("Find");
            }
        }


        void Update()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;
            

            float step = MoveSpeed * Time.deltaTime;
            var trans = InitScript._instance.randomRow.transform;
            for (var i = 0; i < trans.childCount; i++)
            {
                var item = trans.GetChild(i);
                var r_pos = item.position;
                item.position = Vector3.MoveTowards(r_pos, new Vector3(move_x, r_pos.y, r_pos.z), step);

                if (Math.Abs(r_pos.x - move_x)<=1)
                {

                    ResetPosition(item.gameObject);
                    InitScript.UpdateImage(item.gameObject);
                    /*
                    if (x == row_count)
                        GameCoordinator.UpdateState(GameCoordinator.GameStates.PreEnd);
                    else
                        GameCoordinator.UpdateState(GameCoordinator.GameStates.Randoming);
                        */
                }
            }
        }
    }
}
