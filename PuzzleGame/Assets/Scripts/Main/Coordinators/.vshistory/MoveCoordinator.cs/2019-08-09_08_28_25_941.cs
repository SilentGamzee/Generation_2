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
        public Text points;



        //PRIVATE STATIC
        public static MoveCoordinator _instance;


        public static int P
        {
            get => p;
            set
            {
                p = value;
               // _instance.points.text = value + "";
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

            
        }

        public static void ResetPosition()
        {
            
        }

        private static void AddForce(GameObject ball, float up, float right, float left)
        {
            var trans = ball.transform;
            var rb2D = ball.GetComponent<Rigidbody2D>();
            if (up > 0)
                rb2D.AddForce(trans.up * up);
            if (right > 0 && rb2D.velocity.y != 0)
                rb2D.AddForce(trans.right * right);
            if (left > 0 && rb2D.velocity.y != 0)
                rb2D.AddForce(-trans.right * left);
        }

        public static void AddForceToBall(GameObject ball) => AddForce(ball, 0.01f, 0, 0);

        public static void AddForceToBallBottom(GameObject ball) => AddForce(ball, -0.01f, 0, 0);

        public static void AddForceToBallLight(GameObject ball) => AddForce(ball, 0.01f, 0, 0);

        public static void AddForceToBallLeft(GameObject ball) => AddForce(ball, 0.00f, 0, 0.01f);

        public static void AddForceToBallRight(GameObject ball) => AddForce(ball, 0.00f, 0.01f, 0);


      

    }
}
