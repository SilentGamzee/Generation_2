using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VorotaCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (this.gameObject.tag != "game_ball") return;
        if (collision.gameObject.tag == "enemy")
        {
            MoveCoordinator.P++;
            this.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            isGoal = true;
            GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);
            ButtonListener.Lives -= 1;
        }
        if (collision.gameObject.tag == "vorota")
        {
            this.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            isGoal = true;
            GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);
            ButtonListener.Lives -= 1;
        }
    }
}
