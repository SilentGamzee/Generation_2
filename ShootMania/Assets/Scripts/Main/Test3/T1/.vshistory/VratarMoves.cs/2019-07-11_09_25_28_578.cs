using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using Test1;
using UnityEngine;

public class VratarMoves : MonoBehaviour
{
    private Vector3 start_pos;
    public bool isMoveLeft = false;
    void Start()
    {
        start_pos = transform.position;
    }
    float t = 0;
    void Update()
    {
        
        if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving)
        {
            t += Time.deltaTime;
            if (t < 1f) return;
            t = 0;
            isMoveLeft = !isMoveLeft;
            return;
        }
        float need_x;
        if (isMoveLeft)
            need_x = start_pos.x - 2f;
        else
            need_x = start_pos.x + 2f;

        var pos = transform.position;
        var speed = Time.deltaTime*3f;

        transform.position = Vector3.MoveTowards(pos, new Vector3(need_x, pos.y, pos.z), speed);
        if (Mathf.Abs(transform.position.x - need_x) < 0.01f)
            isMoveLeft = !isMoveLeft;
    }
}
