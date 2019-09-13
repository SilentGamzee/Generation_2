using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberButton : MonoBehaviour
{
    public int number;

    public static List<Vector3> number_poses = new List<Vector3>();
    public static int numbers_count;
    void Start()
    {
        number_poses.Add(this.transform.position);
        numbers_count++;
        NumberManager.numbers.Add(this);
    }
}
