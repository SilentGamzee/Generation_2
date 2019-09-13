using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VorotaCollider : MonoBehaviour
{
    public static bool isGoal = false;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag != "game_ball") return;
        if (this.gameObject.tag == "enemy")
        {
            MoveCoordinator.P++;
            this.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            isGoal = true;
            GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);
            ButtonListener.Lives -= 1;
        }
        if (this.gameObject.tag == "vorota")
        {
            this.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            isGoal = true;
            GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);
            ButtonListener.Lives -= 1;
        }
    }
}
