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
        public static bool isGoal = false;
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "vorota")
            {
                MoveCoordinator.P++;
                this.gameObject.GetComponent<Rigidbody2D>().simulated = false;
                isGoal = true;
                GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);
            }
            else if (collision.gameObject.tag == "vratar" && !isGoal)
            {
                MoveCoordinator.P--;
                this.gameObject.GetComponent<Rigidbody2D>().simulated = false;
                this.transform.SetSiblingIndex(3);
                GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);
            }
        }

        void OnTriggerEnter2D(Collider2D collider)
        {

        }
    }
}
