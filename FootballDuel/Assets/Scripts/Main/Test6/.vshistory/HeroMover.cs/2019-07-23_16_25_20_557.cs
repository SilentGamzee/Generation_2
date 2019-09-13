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
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime);
    }
}
