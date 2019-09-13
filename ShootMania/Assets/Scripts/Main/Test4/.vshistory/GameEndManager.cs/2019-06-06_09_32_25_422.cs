using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using Test1;
using UnityEngine;

public class GameEndManager : MonoBehaviour
{
    private static void UpdateWinner()
    {
        
        var trans_col = InitScript._instance.randomCol.transform;
        int itemNum = trans_col.GetChild(0).GetComponent<ItemInfo>().num;

        int count = 0;
        var trans_r = InitScript._instance.randomRow.transform;
        for (var i = 0; i < trans_r.childCount; i++)
        {
            var item = trans_r.GetChild(i);
            var num = item.GetComponent<ItemInfo>().num;
        }

        if (num == 0)
            PlayerManager.Win();
        else
            PlayerManager.Lose();

    }

    void Update()
    {
        if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.GameEnd) return;

        UpdateWinner();
        GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
    }
}
