﻿using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndManager : MonoBehaviour
{
    private static void UpdateWinner()
    {
        var objP = MoveCoordinator.objPoints;
        foreach(var kv in objP)
        {
            if (kv.Value != 3) continue;
            var num = kv.Key.GetComponent<ItemInfo>().num;
            if (num == 0)
            {

            }
        }
    }

    void Update()
    {
        if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.GameEnd) return;

        UpdateWinner();
        GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
    }
}
