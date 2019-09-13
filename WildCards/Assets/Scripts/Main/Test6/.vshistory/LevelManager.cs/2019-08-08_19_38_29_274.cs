using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static void InitLevel(int level)
    {
        Random.InitState(level);
        var cards = new List<CardObject>(CardManager.cardsList);
        var c = 0;
        for (var i = 0; i < cards.Count; i++)
        {

            var n1 = Random.Range(0, cards.Count);
            cards[n1].card_num = c;
            cards.RemoveAt(n1);
        }
    }
}
