using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndManager : MonoBehaviour
{
    private static void UpdateWinner()
    {

        var objP_t = MoveCoordinator.objPoints_y;
        foreach (var kv in objP_t)
        {
            if (kv.Value != 4) continue;
            kv.Key.SetActive(false);
        }

        var objP = MoveCoordinator.objPoints_x;
        foreach (var kv in objP)
        {
            if (kv.Value != 4) continue;
            var num = kv.Key.GetComponent<ItemInfo>().num;
            if (num == 0)
                PlayerManager.Win();
            else
                PlayerManager.Lose();
        }
    }

    void Update()
    {
        if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.GameEnd) return;

        UpdateWinner();
        GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
    }
}
