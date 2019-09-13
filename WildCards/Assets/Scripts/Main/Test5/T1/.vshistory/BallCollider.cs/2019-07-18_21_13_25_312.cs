using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main.Test5.T1
{
    public class BallCollider : MonoBehaviour
    {
        public static bool isGoal = false;
        void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.gameObject.tag == "vratar" && !isGoal)
            {

                this.gameObject.GetComponent<Rigidbody2D>().simulated = false;
                this.transform.SetSiblingIndex(3);
                GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);
                ButtonListener.Lives -= 1;
            }
            else if (collision.gameObject.tag == "vorota")
            {
               
                MoveCoordinator.P++;
                this.gameObject.GetComponent<Rigidbody2D>().simulated = false;
                isGoal = true;
                GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);
                ButtonListener.Lives -= 1;
            }
        }

        private Rigidbody2D rgbd_2d;
        void Start()
        {
            rgbd_2d = this.GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            var vel_x = rgbd_2d.velocity.x;
            if (vel_x <= 0.1f)
                vel_x = 0;
            var vel_y = rgbd_2d.velocity.y;
            if (vel_y <= 0.1f)
                vel_y = 0;
            rgbd_2d.velocity = new Vector2(vel_x, vel_y);
        }
    }
}
