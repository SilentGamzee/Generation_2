using Assets.Scripts.Main;
using System.Collections;
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
    public static int last_number = 0;
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
        if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;
        if (already_accepted) return;

        if (Mathf.Abs(last_number - number) == 1)
        {
            last_number = number;
            NumberManager.AcceptNumber(this);
            already_accepted = true;
        }
        else
        {
            NumberManager.DeclineNumber(this);
            GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);
        }
    }
}
