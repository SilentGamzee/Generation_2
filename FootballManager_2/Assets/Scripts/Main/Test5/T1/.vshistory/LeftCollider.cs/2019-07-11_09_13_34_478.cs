﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCollider : MonoBehaviour
{

    public class RightCollider : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
                MoveCoordinator.AddForceToBallLeft();

        }
    }
}