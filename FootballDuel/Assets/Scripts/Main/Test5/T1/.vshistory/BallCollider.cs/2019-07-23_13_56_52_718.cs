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

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (this.gameObject.tag == "game_ball")
            {
                Vector3 diff = Vector3.zero - this.transform.position;
                diff.Normalize();

                var rb2D = this.gameObject.GetComponent<Rigidbody2D>();
                rb2D.AddForce(diff * 0.1f);
            }
        }

        
    }
}
