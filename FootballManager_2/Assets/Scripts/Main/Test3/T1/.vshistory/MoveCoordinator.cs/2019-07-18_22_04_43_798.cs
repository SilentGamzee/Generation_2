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


        public static int P
        {
            get => p;
            set
            {
                var c = value - p;
                if (c > 0)
                    PlayerManager.Points += c;

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

        }

        public static void ResetPosition()
        {
            var item = _instance.ball.transform;
            item.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            item.position = start_pos;
            item.localScale = Vector3.one;

        }

        private static void AddForce(GameObject ball, float up, float right, float left)
        {
            var trans = ball.transform;
            var rb2D = ball.GetComponent<Rigidbody2D>();
            if (up > 0)
                rb2D.AddForce(trans.up * up);
            if (right > 0 && rb2D.velocity.y != 0)
                rb2D.AddForce(trans.right * right);
            if (left > 0 && rb2D.velocity.y!=0)
                rb2D.AddForce(-trans.right * left);
        }

        public static void AddForceToBall(GameObject ball) => AddForce(ball, 0.05f, 0.02f, 0);

        public static void AddForceToBallLight(GameObject ball) => AddForce(ball, 0.01f, 0, 0);

        public static void AddForceToBallLeft(GameObject ball) => AddForce(ball, 0.00f, 0, 0.01f);

        public static void AddForceToBallRight(GameObject ball) => AddForce(ball, 0.00f, 0.01f, 0);


        void Update()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;

            t += Time.deltaTime;
            if (t < 2f) return;
            t = 0;
            GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
        }
    }
}
