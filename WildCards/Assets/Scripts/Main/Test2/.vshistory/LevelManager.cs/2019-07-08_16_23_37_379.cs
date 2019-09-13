using Assets.Scripts.Main;
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
        InitLevel(current_level);
    }

    void InitLevel(int level)
    {
        var prefab = level_list[level];
        var level_prefab = Instantiate(prefab, parent.transform);
        for (var i = 0; i < level_prefab.transform.childCount; i++)
        {
            var item = level_prefab.transform.GetChild(i);
            var info = item.gameObject.AddComponent<ItemInfo>();
            info.num = 0;
            info.hp = 1;
        }
    }

    public static void OnLevelItemChanged()
    {

    }

    void Update()
    {

    }
}
