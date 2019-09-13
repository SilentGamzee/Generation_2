using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject parent;
    public List<GameObject> level_list;
    public List<Sprite> item_sprites_list;
    
    public int current_level = 0;
    public int count_level_items;
    public int items_level = 1;
    public static LevelManager _instance;
    void Start()
    {
        _instance = this;
        InitLevel(current_level);
    }

    static void InitLevel(int level)
    {
        if(level==3)
        {
            _instance.current_level = 0;
            _instance.items_level++;
            level = 0;
        }

        var prefab = _instance.level_list[level];
        var level_prefab = Instantiate(prefab, _instance.parent.transform);
        _instance.count_level_items = level_prefab.transform.childCount;
        for (var i = 0; i < _instance.count_level_items; i++)
        {
            var item = level_prefab.transform.GetChild(i);
            var info = item.gameObject.AddComponent<ItemInfo>();

            info.num = _instance.items_level - 1;
            info.hp = _instance.items_level;
        }
    }

    public static void OnLevelItemChanged(GameObject item)
    {
        _instance.count_level_items--;
        if (_instance.count_level_items <= 0)
        {
            Destroy(_instance.parent.transform.GetChild(0).gameObject);
            _instance.current_level++;
            MoveCoordinator.ResetPosition();
            InitLevel(_instance.current_level);
        }
    }

    void Update()
    {

    }
}
