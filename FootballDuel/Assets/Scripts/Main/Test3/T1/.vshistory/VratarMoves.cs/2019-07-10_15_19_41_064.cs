﻿using System.Collections;
using System.Collections.Generic;
using Test1;
using UnityEngine;

public class VratarMoves : MonoBehaviour
{
   
    void Start()
    {
        
    }

    void Update()
    {
        var ball_x = InitScript._instance.randomCol.transform.GetChild(1).position.x;
        Debug.Log(ball_x);
    }
}
