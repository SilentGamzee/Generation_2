using Assets.Scripts.Main;
using Assets.Scripts.Main.Test6;
using System.Collections;
using System.Collections.Generic;
using Test1;
using UnityEngine;
using UnityEngine.UI;

public class GameEndManager : MonoBehaviour
{
    public Text coins_text;
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
        
        PanelManager.Get().city_panel.SetActive(true);
        PanelManager.Get().playground_panel.SetActive(false);

        GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
    }
}
