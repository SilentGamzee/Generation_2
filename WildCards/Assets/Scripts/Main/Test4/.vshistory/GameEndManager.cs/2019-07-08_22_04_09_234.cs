using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using Test1;
using UnityEngine;

public class GameEndManager : MonoBehaviour
{
    private static void UpdateWinner()
    {

        ButtonListener.Lives = ButtonListener.Lives_max;
        LevelManager.InitLevel(LevelManager._instance.current_level);

    }

    private float t = 0;
    void Update()
    {
        if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.GameEnd) return;
        t += Time.deltaTime;
        if (t < 2f) return;
        t = 0;
        UpdateWinner();
        GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
    }
}
