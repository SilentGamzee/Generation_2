using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitScript : MonoBehaviour
{
    //PUBLIC EDITOR
    public Sprite empty;
    public List<GameObject> gameRows;
    public GameObject randomRow;
    public List<Sprite> spriteList;

    //PUBLIC STATIC
    public static InitScript _instance;

    void Start()
    {

        _instance = this;

        GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);

        ResetMatrix();
        UpdateStaticImages();
        UpdateImages();

        MoveCoordinator.Init();
    }

    public static void ResetMatrix()
    {
        foreach (var row in _instance.gameRows)
        {
            var trans = row.transform;
            for (var i = 0; i < trans.childCount; i++)
            {
                var item = trans.GetChild(i);
                item.GetComponent<Image>().sprite = _instance.empty;
            }
        }
    }

    private static int r1, r2;
    public static void UpdateStaticImages()
    {
        var spriteList = _instance.spriteList;
        r1 = Random.Range(0, spriteList.Count);
        r2 = Random.Range(0, spriteList.Count);
        if (r2 == r1)
        {
            if (r2 != 0)
                r2--;
            else
                r2++;
        }
    }

    public static void UpdateImages()
    {
        var spriteList = _instance.spriteList;


        var r_row = _instance.randomRow.transform;

        for (var i = 0; i < r_row.childCount; i++)
        {
            var r = Random.Range(0, 2) == 0 ? r1 : r2;
            var item = r_row.GetChild(i);
            item.GetComponent<Image>().sprite = spriteList[r];
        }
    }



}
