using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndManager : MonoBehaviour
{
    

    private static void UpdateWinner()
    {

    }

    void Update()
    {
        var isGameEnd = GameCoordinator.GetGameState() == GameCoordinator.GameStates.GameEnd;
        
        if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.GameEnd) return;

        
    }
}
