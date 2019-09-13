using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberButton : MonoBehaviour
{
    public int number;
    public Image image_component;

    public static List<Vector3> number_poses = new List<Vector3>();
    public static int numbers_count;
    public static int last_number = -1;
    void Start()
    {
        number_poses.Add(this.transform.position);
        numbers_count++;
        NumberManager.numbers.Add(this);
        this.GetComponent<Button>().onClick.AddListener(OnNumber);
    }

    void OnNumber()
    {
        if (last_number == -1)
            last_number = number;
    }
}
