﻿using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bottom")
            GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);
    }
    
    void Update()
    {
        if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving)
        {
            Destroy(this.gameObject);
            return;
        }
        transform.Translate(0, -Time.deltaTime, 0);
    }
}
