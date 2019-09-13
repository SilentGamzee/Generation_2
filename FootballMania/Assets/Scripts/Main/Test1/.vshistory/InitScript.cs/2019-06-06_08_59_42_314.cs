using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Test1
{


public class InitScript : MonoBehaviour
{
    //PUBLIC EDITOR
    public GameObject randomCol;
    public GameObject randomRow;
    public List<Sprite> spriteList;

    //PUBLIC STATIC
    public static InitScript _instance;

    void Start()
    {

        _instance = this;
        UpdateImages();

        MoveCoordinator.Init();
    }


    private static void UpdateImages(Transform trans)
    {
        var spriteList = _instance.spriteList;
        for (var i = 0; i < trans.childCount; i++)
        {
            var r = Random.Range(0, spriteList.Count);
            var item = trans.GetChild(i);
            item.GetComponent<Image>().sprite = spriteList[r];
            item.gameObject.AddComponent<ItemInfo>().num = r;
            item.gameObject.SetActive(true);
        }
    }

    public static void UpdateImages()
    {
        
        var r_col = _instance.randomCol.transform;
        var r_row = _instance.randomRow.transform;
        UpdateImages(r_col);
        UpdateImages(r_row);
    }

    public static void UpdateImage(GameObject item)
    {
        var spriteList = _instance.spriteList;

        var r = Random.Range(0, spriteList.Count);
        item.GetComponent<Image>().sprite = spriteList[r];
        item.GetComponent<ItemInfo>().num = r;
        item.gameObject.SetActive(true);
    }
}
}
