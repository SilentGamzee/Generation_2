using Assets.Scripts.Main;
using Assets.Scripts.Main.Test5.T1;
using System.Collections;
using System.Collections.Generic;
using Test1;
using UnityEngine;

public class GameEndManager : MonoBehaviour
{
    private static void UpdateWinner()
    {
        MoveCoordinator.ResetPosition();
        MoveCoordinator._instance.ball.transform.SetSiblingIndex(1);
        VorotaCollider.isGoal = false;
        if(ButtonListener.Lives <= 0)
        {
            MenuManager.OnReturn();
            ButtonListener.Lives = ButtonListener.Lives_max;
        }
    }

    private float t = 0;
    void Update()
    {
        if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.GameEnd) return;
       // t += Time.deltaTime;
        //if (t < 2f) return;
        //t = 0;
       // UpdateWinner();
        GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
    }
}
