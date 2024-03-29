﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberButton : MonoBehaviour
{
    public int number;
    public Image image_component;
    public bool already_accepted = false;

    public static List<Vector3> number_poses = new List<Vector3>();
    public static int numbers_count;
    public static int last_number = -1;
    void Start()
    {
        image_component = this.GetComponent<Image>();
        number_poses.Add(this.transform.position);
        numbers_count++;
        NumberManager.numbers.Add(this);
        this.GetComponent<Button>().onClick.AddListener(OnNumber);
    }

    void OnNumber()
    {
        if (already_accepted) return;
        if (last_number == -1)
        {
            last_number = number;
            NumberManager.AcceptNumber(this);
            already_accepted = true;
            return;
        }
        if (Mathf.Abs(last_number - number) == 1)
        {
            last_number = number;
            NumberManager.AcceptNumber(this);
            already_accepted = true;
        }

    }
}
