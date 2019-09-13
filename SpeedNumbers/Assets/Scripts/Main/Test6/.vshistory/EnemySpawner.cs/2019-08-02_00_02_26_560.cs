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
    void Start()
    {
        spawn_time = Random.Range(min_spawn_time, max_spawn_time);
    }

    void Update()
    {
        t += Time.deltaTime;
        if (t < spawn_time) return;
    }
}
