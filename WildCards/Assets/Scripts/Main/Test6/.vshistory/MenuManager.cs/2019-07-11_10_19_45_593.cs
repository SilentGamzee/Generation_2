using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public GameObject menuButtonsPanel;
    public GameObject gameModePanel;
    void Start()
    {
        startButton.onClick.AddListener(OnStart);
        exitButton.onClick.AddListener(OnExit);
    }


    void OnStart()
    {
        menuButtonsPanel.SetActive(false);
        gameModePanel.SetActive(true);
    }

    void OnExit()
    {
        Application.Quit();
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
