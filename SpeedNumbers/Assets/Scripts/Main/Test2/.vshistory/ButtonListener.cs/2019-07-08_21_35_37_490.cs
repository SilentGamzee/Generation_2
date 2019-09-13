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
    class ButtonListener : MonoBehaviour
    {
        public Button PlayButton;
        public Button PauseButton;
        public Button StartButton;
        public Button shopButton;

        public Transform top;
        public Transform bottom;

        public GameObject arrow;
        public Text extra_jump_text;

        public static ButtonListener _instance;

        public static int extra_jump { get => extra_jump1;
            set
            {
                extra_jump1 = value;

            }
        }
        void Start()
        {
            _instance = this;

            StartButton.onClick.AddListener(OnStartButton);

        }

        public static void OnStartButton()
        {
            //if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart) return;
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _instance.arrow.transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            if (Math.Abs(Quaternion.Euler(0f, 0f, rot_z - 90).z) > 0.5f) return;

            PlayerManager.Round++;
            var trans_col = InitScript._instance.randomCol.transform;
            var item = trans_col.GetChild(0);
            item.GetComponent<Rigidbody2D>().simulated = true;

            GameCoordinator.UpdateState(GameCoordinator.GameStates.Moving);



            //  MoveCoordinator.AddForceToBall();

            var rb2D = item.GetComponent<Rigidbody2D>();
            rb2D.AddForce(diff * 1.2f);

        }



        public static void ResetStats()
        {

        }

        private float t = 0;
        private static float avgHeightValue1;
        private static int extra_jump1;

        void Update()
        {
            var trans_col = InitScript._instance.randomCol.transform;
            var item = trans_col.GetChild(0);
            var rb2D = item.GetComponent<Rigidbody2D>();
            var vel = rb2D.velocity;
            if (vel.y > 10)
                vel.y = 8;
            rb2D.velocity = vel;

            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart) return;


            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - arrow.transform.position;
            diff.Normalize();


            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            var euler = Quaternion.Euler(0f, 0f, rot_z - 90);
            if (Math.Abs(euler.z) <= 0.5f)
                arrow.transform.rotation = euler;
        }
    }
}
