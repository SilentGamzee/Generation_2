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

            if (collision.gameObject.tag == "side_wall")
            {

                Vector3 diff = last_target - transform.position;
                diff.Normalize();
                rigid.AddForce(diff * 0.01f);
            }

            if (collision.gameObject.tag == "myhero")
            {
                var vector = ButtonListener._instance.enemy_hero.transform.forward;
                last_target = ButtonListener._instance.enemy_hero.transform.position;
                if (UnityEngine.Random.Range(0, 100) < 50)
                    vector += ButtonListener._instance.enemy_hero.transform.up;
                else
                    vector -= ButtonListener._instance.enemy_hero.transform.up;
                Vector3 diff = vector - transform.position;
                diff.Normalize();
                rigid.AddForce(diff);
                PlayerManager.Points++;
            }
            else if (collision.gameObject.tag == "enemy")
            {
                var vector = ButtonListener._instance.myhero.transform.forward;
                last_target = ButtonListener._instance.myhero.transform.position;
                if (UnityEngine.Random.Range(0, 100) < 50)
                    vector += ButtonListener._instance.myhero.transform.up;
                else
                    vector -= ButtonListener._instance.myhero.transform.up;
                Vector3 diff = vector - transform.position;
                diff.Normalize();
                rigid.AddForce(diff);
                PlayerManager.Points++;
            }
        }

    }
}
