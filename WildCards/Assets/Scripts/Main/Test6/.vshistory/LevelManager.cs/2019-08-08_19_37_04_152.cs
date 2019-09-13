using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static void InitLevel(int level)
    {
        var cards = new List<CardObject>(CardManager.cardsList);
        var c = 0;
        for (var i = 0; i < cards.Count; i++)
        {
            var f1 = Random.Range()
        }
    }
}
