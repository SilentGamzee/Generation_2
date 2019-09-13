using Assets.Scripts.Main;
using Assets.Scripts.Main.Test6;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy_prefab;
    public float min_spawn_time = 1;
    public float max_spawn_time = 3;
    public float spawn_time = -1;

    private float t = 0;
    public static int spawn_count;
    void Start()
    {
        spawn_time = Random.Range(min_spawn_time, max_spawn_time);
    }

    void Update()
    {
        if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.Moving) return;
        if (spawn_count + 1 > HardModeButton.static_wave_count) return;
        t += Time.deltaTime;
        if (t < spawn_time) return;
        t = 0;
        spawn_time = Random.Range(min_spawn_time + HardModeButton.static_spawn_bonus_time, max_spawn_time + HardModeButton.static_spawn_bonus_time);
        Instantiate(enemy_prefab, this.transform);
        spawn_count++;
    }
}
