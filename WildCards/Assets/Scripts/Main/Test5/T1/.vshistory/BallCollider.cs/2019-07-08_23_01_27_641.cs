using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Main.Test5.T1
{
    public class BallCollider:MonoBehaviour
    {
        public static int ball_damage = 1;
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "enemy")
            {
                collision.gameObject.GetComponent<ItemInfo>().DealDamage(ball_damage);
                MoveCoordinator.AddForceToBallLight();
            }

            if (collision.gameObject.tag == "bottom")
            {
                MoveCoordinator.ResetPosition();
                GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
                ButtonListener.extra_jump = ButtonListener.extra_jump_max;
                ButtonListener.Lives--;
            }
        }
    }
}
