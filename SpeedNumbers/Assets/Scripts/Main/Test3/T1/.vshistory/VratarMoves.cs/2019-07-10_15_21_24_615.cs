using System.Collections;
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
        var pos = transform.position;
        var speed = Time.deltaTime;
        transform.position = Vector3.MoveTowards(pos, new Vector3(ball_x, pos.y, pos.z), speed);
    }
}
