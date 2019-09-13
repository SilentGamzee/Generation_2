using Assets.Scripts.Main;
using Assets.Scripts.Main.Test6;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberManager : MonoBehaviour
{
    public int time_per_game;
    public Sprite accepted_number;
    public Sprite declined_number;
    public Sprite usual_number;
    public Image progress_bar;

    public static List<NumberButton> numbers = new List<NumberButton>();
    public static float total_time = 0;
    private static NumberManager _instance;
    private static float time;

    void Start()
    {
        _instance = this;

    }

    public static NumberManager Get() => _instance;

    public static void ResetNumbers()
    {
        NumberButton.last_number = 0;
        time = 0;
        total_time = _instance.time_per_game + HardModeButton.static_bonus_time + PlayerManager.player_speed_lvl;
        var poses = new List<Vector3>(NumberButton.number_poses);
        numbers.ForEach(x =>
        {
            x.image_component.sprite = _instance.usual_number;
            x.already_accepted = false;
            var c = Random.Range(0, poses.Count);
            x.transform.position = poses[c];
            poses.RemoveAt(c);
        });
    }

    public static void AcceptNumber(NumberButton number) => number.image_component.sprite = _instance.accepted_number;

    public static void DeclineNumber(NumberButton number) => number.image_component.sprite = _instance.declined_number;

    void Update()
    {
        if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;
        time += Time.deltaTime;
        progress_bar.fillAmount = time / total_time;
        if (time >= total_time)
        {
            MoveCoordinator.P = 0;
            GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);
        }
    }
}
