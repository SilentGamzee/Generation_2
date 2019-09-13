using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCollider : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "game_ball")
        MoveCoordinator.AddForceToBallLeft(collision.gameObject);
    }
}
