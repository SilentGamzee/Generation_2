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



        private static Vector3 start_pos;
        private static float korzina_y;

        public static int P
        {
            get => p;
            set
            {
                p = value;
                _instance.pointsVorotaText.text = "Points: " + value;
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
            start_pos = trans_col.GetChild(0).position;
            korzina_y = trans_col.GetChild(1).position.y;
        }

        public static void ResetPosition()
        {
            var trans_col = InitScript._instance.randomCol.transform;
            var item = trans_col.GetChild(0);
            
           
            item.GetComponent<Rigidbody2D>().simulated = false;
            item.position = start_pos;
        }

        public static void AddForceToBall()
        {
            var trans_col = InitScript._instance.randomCol.transform;
            var item = trans_col.GetChild(0);
            var rb2D = item.GetComponent<Rigidbody2D>();
            rb2D.AddForce(item.up * 0.05f);
            rb2D.AddForce(item.right * 0.02f);
        }

        public static void AddForceToBallLight()
        {
            var trans_col = InitScript._instance.randomCol.transform;
            var item = trans_col.GetChild(0);
            var rb2D = item.GetComponent<Rigidbody2D>();
            rb2D.AddForce(item.up * 0.01f);
        }

        public static void AddForceToBallLeft()
        {
            var trans_col = InitScript._instance.randomCol.transform;
            var item = trans_col.GetChild(0);
            var rb2D = item.GetComponent<Rigidbody2D>();
            rb2D.AddForce(item.up * 0.02f);
            rb2D.AddForce(-item.right * 0.01f);
        }

        public static void AddForceToBallRight()
        {
            var trans_col = InitScript._instance.randomCol.transform;
            var item = trans_col.GetChild(0);
            var rb2D = item.GetComponent<Rigidbody2D>();
            rb2D.AddForce(item.up * 0.02f);
            rb2D.AddForce(-item.right * 0.01f);
        }

        void Update()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;

        }
    }
}
