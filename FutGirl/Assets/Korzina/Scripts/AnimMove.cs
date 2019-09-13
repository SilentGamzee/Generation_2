using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMove : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(transform.position.y), transform.position.z);
    }
}
