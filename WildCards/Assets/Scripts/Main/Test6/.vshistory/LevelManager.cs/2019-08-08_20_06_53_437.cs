﻿using Assets.Scripts.Main.Test6;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static void InitLevel(int level)
    {
        Random.InitState(level);
        var cards = new List<CardObject>(CardManager._instance.cardsList);
        var c = 0;
        var count = cards.Count;
        for (var i = 0; i < count; i++)
        {
            Debug.Log(cards.Count);
            for (var k = 0; k < 2; k++)
            {
                var n = Random.Range(0, cards.Count);
                cards[n].card_num = c;
                cards.RemoveAt(n);
            }
            c++;
        }
        PanelManager.OpenGamePanel();
    }
}