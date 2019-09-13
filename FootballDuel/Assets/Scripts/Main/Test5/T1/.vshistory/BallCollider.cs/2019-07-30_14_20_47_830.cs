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
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "wall")
                Destroy(this.gameObject);

        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "myhero")
            {
                Vector3 diff = ButtonListener._instance.enemy_hero.transform.position - transform.position;
                diff.Normalize();
                rigid.AddForce(diff * 0.03f);
            }else if(collider.gameObject.tag == "enemy")
            {
                Vector3 diff = ButtonListener._instance.myhero.transform.position - transform.position;
                diff.Normalize();
                rigid.AddForce(diff * 0.03f);
            }
        }


    }
}
