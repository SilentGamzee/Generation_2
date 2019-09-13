﻿using System;
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

        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "enemy" && isAlly)
            {
                Destroy(this.gameObject);
                ButtonListener.LivesEnemy--;
            }
            else if (collider.gameObject.tag == "myhero" && !isAlly)
            {
                Destroy(this.gameObject);
                ButtonListener.Lives--;
            }
        }


    }
}