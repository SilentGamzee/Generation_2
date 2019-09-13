using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    void Update()
    {
        transform.Translate(0, -Time.deltaTime, 0);
    }
}
