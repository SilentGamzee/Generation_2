using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    void Start()
    {
        startButton.onClick.AddListener(OnStart);
        exitButton.onClick.AddListener(OnExit);
    }


    void OnStart()
    {

    }

    void OnExit()
    {

    }


    void OnEasy()
    {

    }

    void OnNormal()
    {

    }

    void OnHard()
    {

    }
   
}
