using Assets.Scripts.Main;

using System.Collections;
using System.Collections.Generic;
using Test1;
using UnityEngine;

public class GameEndManager : MonoBehaviour
{
    private static void UpdateWinner()
    {
        
        
    }

    private float t = 0;
    void Update()
    {
        if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.GameEnd) return;
        t += Time.deltaTime;
        if (t < 1.5f) return;
        t = 0;
        isGameEnd = false;
        PanelManager.Get().city_panel.SetActive(true);
        PanelManager.Get().playground_panel.SetActive(false);

        GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
    }
}
