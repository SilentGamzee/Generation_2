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
        public static bool isGoal = flase;
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "vorota")
            {
                MoveCoordinator.P++;
                isGoal = true
                return;
            }

            
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            
        }
    }
}
