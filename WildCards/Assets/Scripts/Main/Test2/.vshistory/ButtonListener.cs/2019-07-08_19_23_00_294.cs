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

        public Transform top;
        public Transform bottom;

        public GameObject arrow;

        public static ButtonListener _instance;


        void Start()
        {
            _instance = this;

            StartButton.onClick.AddListener(OnStartButton);

        }

        public static void OnStartButton()
        {
            //if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart) return;


            PlayerManager.Round++;
            var trans_col = InitScript._instance.randomCol.transform;
            var item = trans_col.GetChild(0);
            item.GetComponent<Rigidbody2D>().simulated = true;

            GameCoordinator.UpdateState(GameCoordinator.GameStates.Moving);

            MoveCoordinator.P++;
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - arrow.transform.position;
            diff.Normalize();
            //  MoveCoordinator.AddForceToBall();

            var rb2D = item.GetComponent<Rigidbody2D>();
            rb2D.AddForce(diff * 0.05f);
        }



        public static void ResetStats()
        {

        }

        private float t = 0;
        private static float avgHeightValue1;

        void Update()
        {
            if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.WaitingToStart) return;





            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            var euler = Quaternion.Euler(0f, 0f, rot_z - 90);
            if (Math.Abs(euler.z) <= 0.5f)
                arrow.transform.rotation = euler;
            Debug.Log(arrow.transform.rotation);
        }
    }
}
