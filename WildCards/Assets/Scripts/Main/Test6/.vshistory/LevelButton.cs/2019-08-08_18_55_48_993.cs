using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int level;


    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnLevelButton);
    }

    void OnLevelButton()
    {
        Random.InitState(level);

    }
}
