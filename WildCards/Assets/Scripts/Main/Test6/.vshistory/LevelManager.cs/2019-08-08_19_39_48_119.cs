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
            for(var k=0;k<2;k++)
            {
                var n = Random.Range(0, cards.Count);
                cards[n].card_num = c;
                cards.RemoveAt(n);
            }

            var n2 = Random.Range(0, cards.Count);
            cards[n2].card_num = c;
            cards.RemoveAt(n2);
            c++;
        }
    }
}
