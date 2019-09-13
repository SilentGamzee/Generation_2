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
        public bool isAlly = false;

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "wall")
                Destroy(this.gameObject);
            else if (collision.gameObject.tag == "enemy" && isAlly)
                MoveCoordinator.P++;
            else if (collision.gameObject.tag == "myhero" && !isAlly)
                MoveCoordinator.enemy_P++;
        }

        
    }
}
