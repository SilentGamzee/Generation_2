﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberManager : MonoBehaviour
{
    public Sprite accepted_number;
    public Sprite declined_number;
    public Sprite usual_number;

    public static List<NumberButton> numbers = new List<NumberButton>();
    private static NumberManager _instance;
    void Start()
    {
        _instance = this;
    }

    public static void ResetNumbers() => numbers.ForEach(x => x.image_component.sprite = _instance.usual_number);



}
