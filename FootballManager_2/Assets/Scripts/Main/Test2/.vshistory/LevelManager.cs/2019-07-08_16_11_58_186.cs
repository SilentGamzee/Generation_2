using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject parent;
    public List<GameObject> level_list;

    public int current_level = 0;
    void Start()
    {
        
    }

    void InitLevel(int level)
    {
        var prefab = level_list[level];
        var level_prefab = Instantiate(prefab, parent);
    }

    void Update()
    {
        
    }
}
