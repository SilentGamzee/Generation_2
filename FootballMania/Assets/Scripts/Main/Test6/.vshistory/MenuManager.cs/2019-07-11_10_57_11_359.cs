﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public GameObject menuButtonsPanel;
    public GameObject gameModePanel;
    public GameObject hardChoosePanel;
    public Button easyButton;
    public Button normalButton;
    public Button hardButton;
    public List<Button> returnButtons;
    public Button standartButton;
    public Button marksButton;

    private static MenuManager _instance;
    void Start()
    {
        startButton.onClick.AddListener(OnStart);
        exitButton.onClick.AddListener(OnExit);
        easyButton.onClick.AddListener(OnEasy);
        normalButton.onClick.AddListener(OnNormal);
        hardButton.onClick.AddListener(OnHard);
        foreach (var butt in returnButtons)
            butt.onClick.AddListener(OnReturn);

        standartButton.onClick.AddListener(OnStandart);
        marksButton.onClick.AddListener(OnMarks);

        OnReturn();
    }


    void OnStart()
    {
        menuButtonsPanel.SetActive(false);
        gameModePanel.SetActive(true);
        hardChoosePanel.SetActive(false);
    }

    void OnExit()
    {
        Application.Quit();
    }

    void OnStandart()
    {
        menuButtonsPanel.SetActive(false);
        gameModePanel.SetActive(false);
        hardChoosePanel.SetActive(true);
    }

    void OnMarks()
    {
        menuButtonsPanel.SetActive(false);
        gameModePanel.SetActive(false);
        hardChoosePanel.SetActive(true);
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

    public static void OnReturn()
    {
        menuButtonsPanel.SetActive(true);
        gameModePanel.SetActive(false);
        hardChoosePanel.SetActive(false);
    }

    

}
