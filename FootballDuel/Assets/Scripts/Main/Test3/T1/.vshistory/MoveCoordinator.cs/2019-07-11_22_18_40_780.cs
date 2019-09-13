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
        public GameObject ball;


        //PRIVATE STATIC
        public static MoveCoordinator _instance;
        private static List<Vector3> points = new List<Vector3>();
        private static Vector3 nextPoint;



        private static Vector3 start_pos;
        private static float korzina_y;

        private static float start_ball_coll_size;

        public static int P
        {
            get => p;
            set
            {
                var c = value - p;
                p = value;
                _instance.pointsVorotaText.text = "" + value;
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
            /*
            var trans_col = InitScript._instance.randomCol.transform;
            for (var i = 0; i < trans_col.childCount; i++)
            {
                var item = trans_col.GetChild(i);
                var pos = item.transform.position;
                
            }
            */
            var trans_col = InitScript._instance.randomCol.transform;
            start_pos = _instance.ball.transform.position;
            korzina_y = trans_col.GetChild(0).position.y;
            start_ball_coll_size = trans_col.GetChild(1).GetComponent<CircleCollider2D>().radius;
        }

        public static void ResetPosition()
        {
            var item = _instance.ball.transform;
            item.GetComponent<Rigidbody2D>().simulated = false;
            item.position = start_pos;
            item.localScale = Vector3.one;

            item.GetComponent<CircleCollider2D>().radius = start_ball_coll_size;
        }

        private static void AddForce(float up, float right, float left)
        {
            var trans_col = InitScript._instance.randomCol.transform;
            var item = _instance.ball.transform;
            var rb2D = item.GetComponent<Rigidbody2D>();
            rb2D.AddForce(item.up * up);
            rb2D.AddForce(item.right * right);
            rb2D.AddForce(-item.right * left);
        }

        public static void AddForceToBall() => AddForce(0.05f, 0.02f, 0);

        public static void AddForceToBallLight() => AddForce(0.01f, 0, 0);

        public static void AddForceToBallLeft() => AddForce(0.02f, 0, 0.03f);

        public static void AddForceToBallRight() => AddForce(0.02f, 0.03f, 0);

        private static bool isMoveLeft = false;
        void Update()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;

            var item = _instance.ball.transform;
            var dist = Math.Abs(item.position.y - korzina_y) / 7f;

            if (dist > 0.3f && dist <= 1f)
            {
                item.localScale = new Vector3(dist, dist, dist);
                item.GetComponent<CircleCollider2D>().radius = dist;
            }

        }
    }
}
