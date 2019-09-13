using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberManager : MonoBehaviour
{
    public Sprite accepted_number;
    public Sprite declined_number;
    public Sprite usual_number;

    public Image progress_bar;
    public Button ok_button;
    public Text coins_text;

    public static List<NumberButton> numbers = new List<NumberButton>();
    private static NumberManager _instance;
    void Start()
    {
        _instance = this;
        ok_button.onClick.AddListener(OnOkButton);
    }

    public static NumberManager Get() => _instance;

    public static void ResetNumbers()
    {
        var poses = new List<Vector3>(NumberButton.number_poses);
        numbers.ForEach(x => {
            x.image_component.sprite = _instance.usual_number;
            x.already_accepted = false;
            var c = Random.Range(0, poses.Count);
            x.transform.position = poses[c];
            poses.RemoveAt(c);
        });
    }

    public static void AcceptNumber(NumberButton number) => number.image_component.sprite = _instance.accepted_number;

    public static void DeclineNumber(NumberButton number) => number.image_component.sprite = _instance.declined_number;
}
