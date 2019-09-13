﻿using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using Test1;
using UnityEngine;

public class VratarMoves : MonoBehaviour
{
    void Update()
    {
        if(GameCoordinator.GetGameState() !=GameCoordinator.GameStates.Moving)
        var ball_x = InitScript._instance.randomCol.transform.GetChild(1).position.x;
        var pos = transform.position;
        var speed = Time.deltaTime;
        Debug.Log(ball_x);
        if (Mathf.Abs(ball_x) > 2f) return;
        transform.position = Vector3.MoveTowards(pos, new Vector3(ball_x, pos.y, pos.z), speed);
    }
}
