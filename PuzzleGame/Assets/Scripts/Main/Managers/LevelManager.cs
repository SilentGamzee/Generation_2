using Assets.Scripts.Main;
using Assets.Scripts.Main.Test6;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static int current_lvl = -1;

    public static void InitLevel(int level)
    {
        current_lvl = level;
        Random.InitState(level);

        var poses = new List<Vector3>(PuzzleManager.initPoses);
        var count = poses.Count;
        for (var i = 0; i < count; i++)
        {
            var n = Random.Range(0, poses.Count);
            PuzzleManager._instance.puzzles[i].transform.position = poses[n];
            poses.RemoveAt(n);
        }

        PlayerManager.P = 0;
        PuzzleManager.IsPlaying = true;
        PuzzleManager.time = 0;
        PuzzleManager.total_time = 20 - level * 2 + PlayerManager.player_switch_lvl;

        PanelManager.OpenGamePanel();
    }
}
