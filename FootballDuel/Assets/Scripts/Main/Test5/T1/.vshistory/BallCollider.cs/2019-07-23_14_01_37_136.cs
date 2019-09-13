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
            Debug.Log(collision.gameObject.tag);
        }

        
    }
}
