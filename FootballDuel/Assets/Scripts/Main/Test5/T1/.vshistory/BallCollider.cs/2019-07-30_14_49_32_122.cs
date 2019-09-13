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
        Rigidbody2D rigid;
        void Start()
        {
            rigid = gameObject.GetComponent<Rigidbody2D>();
        }

        private Vector3 last_target;
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "wall")
            {
                ButtonListener.Lives--;
                return;
            }

            if (collision.gameObject.tag == "right wall")
            {
                ButtonListener.LivesEnemy--;
                return;
            }

            if (collision.gameObject.tag == "myhero")
            {
                last_target = ButtonListener._instance.myhero.transform.position;
                Vector3 diff = ButtonListener._instance.enemy_hero.transform.position - transform.position;
                diff.Normalize();
                rigid.AddForce(diff * 0.03f);
            }
            else if (collision.gameObject.tag == "enemy")
            {
                last_target = ButtonListener._instance.myhero.transform.position;
                Vector3 diff = last_target - transform.position;
                diff.Normalize();
                rigid.AddForce(diff * 0.03f);
            }
        }

    }
}
