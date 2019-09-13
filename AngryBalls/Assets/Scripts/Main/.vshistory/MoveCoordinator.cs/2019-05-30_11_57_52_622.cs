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

        //PRIVATE STATIC
        private static List<float> x_points = new List<float>();
        private static Dictionary<GameObject, int> objPoints = new Dictionary<GameObject, int>();

        private static float start_x;
        private static int x = 0;
        private static float delay = 0;
        private static int row_count = 0;

        //PUBLIC STATIC
        public static int winner;

        public static void Init()
        {
            var trans = InitScript._instance.randomRow.transform;
            for (var i = 0; i < trans.childCount; i++)
            {
                var item = trans.GetChild(i);
                var x_pos = item.transform.position.x;
                x_points.Add(x_pos);
                if (i == 0)
                {
                    Destroy(item.gameObject);
                    continue;
                }
                objPoints.Add(item.gameObject, i);

            }

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
            var temp = _item.transform.position;
            temp.x = start_x;
            _item.transform.position = temp;


        }

        private static void UpdatePosition(GameObject _item)
        {
            var lastPos = objPoints[_item];
            if (lastPos == 0)
            {
                ResetPosition(_item);
                InitScript.UpdateImage(_item);
                objPoints[_item] = x_points.Count - 1;
                return;
            }
            if (!objPoints.ContainsValue(lastPos - 1))
                objPoints[_item] = lastPos - 1;
        }

        private static void PostUpdate()
        {

            var list = objPoints.Values.OrderBy(i => i).ToList();
            int last = list[0];
            int broken = -1;
            var s = "";
            foreach (var v in list)
            {
                s += v + " ";
                if (last == v
                    || Math.Abs(last - v) == 1)
                {
                    last = v;
                    continue;
                }

                broken = v;

            }
            Debug.Log(s);
            if (broken != -1)
                Debug.Log("Broken: " + last + " -> " + broken);
        }

        private static float t = 0;
        void Update()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;
            t += Time.deltaTime;

            

            float param = Mathf.InverseLerp(0, 1, TimeDelay/t);

            float step = MoveSpeed * param * Time.deltaTime;
            var trans = InitScript._instance.randomRow.transform;
            for (var i = 0; i < trans.childCount; i++)
            {
                var item = trans.GetChild(i);
                var move_x = x_points[objPoints[item.gameObject]];
                var r_pos = item.position;
                item.position = Vector3.MoveTowards(r_pos, new Vector3(move_x, r_pos.y, r_pos.z), step);

                if (Math.Abs(r_pos.x - move_x) <= 0.1f)
                {
                    if (t < TimeDelay)
                        UpdatePosition(item.gameObject);
                    else
                        GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);


                    // else
                    //     PostUpdate();

                    /*
                    if (x == row_count)
                        
                    else
                        GameCoordinator.UpdateState(GameCoordinator.GameStates.Randoming);
                        */
                }
            }
        }
    }
}
