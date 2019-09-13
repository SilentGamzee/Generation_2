using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMover : MonoBehaviour
{
    public Transform top;
    public Transform bottom;
    public bool isMovingBottom;

    void Update()
    {
        Vector3 pos;
        if (isMovingBottom)
            pos = bottom.position;
        else
            pos = top.position;
        pos.x = transform.position.x;
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime* (PlayerManager.player_speed_lvl * 0.01f));
        if(Mathf.Abs(pos.y - transform.position.y) <= 0.1f)
            isMovingBottom = !isMovingBottom;
    }
}
