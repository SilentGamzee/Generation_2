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
        private static List<float> y_points = new List<float>();
        private static List<float> x_points = new List<float>();

        private static float start_y;
        private static float start_x;
       
      
   

        //PUBLIC STATIC
        public static Dictionary<GameObject, int> objPoints = new Dictionary<GameObject, int>();

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
                objPoints.Add(item.gameObject, i);
            }

            start_y = trans_col.GetChild(trans_col.childCount - 1).position.y;
            start_x = trans_col.GetChild(trans_col.childCount - 1).position.y;


        }




        private static void ResetPosition()
        {
            var trans = InitScript._instance.randomCol.transform;
            for (var i = 0; i < trans.childCount; i++)
            {
                var item = trans.GetChild(i);
                var temp = item.transform.position;
                temp.y = y_points[objPoints[item.gameObject]];
                item.transform.position = temp;
                
            }

           
        }

        private static void ResetPosition(GameObject _item)
        {
            var temp = _item.transform.position;
            temp.y = start_y;
            _item.transform.position = temp;


        }

        private static void UpdatePosition(GameObject _item)
        {
            var lastPos = objPoints[_item];
            if (lastPos == 0)
            {
                ResetPosition(_item);
                InitScript.UpdateImage(_item);
                objPoints[_item] = y_points.Count - 1;
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

            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving)
            {
               if(GameCoordinator.GetGameState()!=GameCoordinator.GameStates.Pause)
                {
                    t = 0;
                    PlayerManager.UpdateRoundProgress(t / TimeDelay * 100);
                }
                        
                return;
            }
            t += Time.deltaTime;
            PlayerManager.UpdateRoundProgress(t/TimeDelay*100);
            

            float param = Mathf.InverseLerp(0, 1, TimeDelay/t/5f);

            float step = MoveSpeed * param * Time.deltaTime;
            var trans = InitScript._instance.randomCol.transform;
            for (var i = 0; i < trans.childCount; i++)
            {
                var item = trans.GetChild(i);
                var move_y = y_points[objPoints[item.gameObject]];
                var r_pos = item.position;
                item.position = Vector3.MoveTowards(r_pos, new Vector3(r_pos.x, move_y, r_pos.z), step);

                if (Math.Abs(r_pos.y - move_y) <= 0.1f)
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
    }
}
