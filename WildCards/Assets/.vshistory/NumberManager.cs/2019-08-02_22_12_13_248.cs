using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberManager : MonoBehaviour
{
    public Sprite accepted_number;
    public Sprite declined_number;
    public Sprite usual_number;

    public static List<NumberButton> numbers = new List<NumberButton>();
    public static List<Vector3> number_poses = new List<Vector3>();
    private static NumberManager _instance;
    void Start()
    {
        _instance = this;
    }

    public static NumberManager Get() => _instance;

    public static void ResetNumbers()
    {
        var poses = 
        numbers.ForEach(x => {
            x.image_component.sprite = _instance.usual_number;
            x.already_accepted = false;
        });
    }

    public static void AcceptNumber(NumberButton number) => number.image_component.sprite = _instance.accepted_number;

    public static void DeclineNumber(NumberButton number) => number.image_component.sprite = _instance.declined_number;
}
