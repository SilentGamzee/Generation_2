﻿using Assets.Scripts.Main;
using Assets.Scripts.Main.Test6;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static int current_lvl = -1;

    public static void InitLevel(int level)
    {
        Random.InitState(level);
        var cards = new List<CardObject>(CardManager._instance.cardsList);
        var c = 0;
        var count = cards.Count / 2;
        for (var i = 0; i < count; i++)
        {
            for (var k = 0; k < 2; k++)
            {
                var n = Random.Range(0, cards.Count);
                cards[n].card_num = c;
                cards[n].isThisErrorOpened = false;
                CardManager.CloseSprite(cards[n]);
                cards.RemoveAt(n);
            }
            c++;
        }

        CardManager.opened = 0;
        CardManager.need_open = count;
        CardManager.error_count = 0;
        CardManager.ErrorsTextUpdate();
        CardManager.UpdateCardProgress();

        MoveCoordinator.P = 0;

        CardObject.Reset();

        PanelManager.OpenGamePanel();
    }
}
