using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalerImage : MonoBehaviour
{
    void Update()
    {
        if(transform.localScale.x < 2)
        {
            transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime,1);
        }
        else
        {
            
        }
    }
}
