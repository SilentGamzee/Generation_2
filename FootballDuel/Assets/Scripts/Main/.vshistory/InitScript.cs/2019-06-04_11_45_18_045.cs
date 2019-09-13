using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainStarto : MonoBehaviour
{
    //PUBLIC EDITOR
    public Sprite emptySprite;
    public GameObject fRow;
    public List<Sprite> ListSprites;

    //PUBLIC STATIC
    public static MainStarto _instance;

    void Start()
    {

        _instance = this;
        UpdateImages();

        MoveCoordinator.Init();
    }




    public static void UpdateImages()
    {
        var spriteList = _instance.spriteList;
        var r_row = _instance.fRow.transform;

        for (var i = 0; i < r_row.childCount; i++)
        {
            var r = Random.Range(0, spriteList.Count);
            var item = r_row.GetChild(i);
            item.GetComponent<Image>().sprite = spriteList[r];
            item.gameObject.AddComponent<ItemInfo>().num = r;
        }
    }

    public static void UpdateImage(GameObject item)
    {
        var spriteList = _instance.spriteList;

        var r = Random.Range(0, spriteList.Count);
        item.GetComponent<Image>().sprite = spriteList[r];
        item.GetComponent<ItemInfo>().num = r;
    }



}
