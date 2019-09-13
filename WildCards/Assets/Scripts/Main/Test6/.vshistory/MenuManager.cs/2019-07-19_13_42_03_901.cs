using Assets.Scripts.Main;
using Assets.Scripts.Main.Test5.T1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public GameObject menuButtonsPanel;

    public Button standartButton;
    public Button marksButton;

    public GameObject sure_panel;
    public Button not_sure;
    public Button yes_sure;

    public GameObject menu;

    private static MenuManager _instance;
    void Start()
    {
        _instance = this;
        startButton.onClick.AddListener(OnStart);
        exitButton.onClick.AddListener(OnExit);


        standartButton.onClick.AddListener(OnStandart);
   
       
        not_sure.onClick.AddListener(OnNotSure);
        yes_sure.onClick.AddListener(OnYesSure);

        OnReturn();
    }

   


    void OnStart()
    {
        menuButtonsPanel.SetActive(false);
        ButtonListener._instance.city_panel.SetActive(true);
    }

    void OnExit()
    {
        sure_panel.SetActive(true);
    }

    void OnNotSure()
    {
        sure_panel.SetActive(false);
    }

    void OnYesSure()
    {
        Application.Quit();
    }

    void OnStandart()
    {
        menuButtonsPanel.SetActive(false);


        MoveCoordinator.P = 0;

        MoveCoordinator.ResetPosition();
        GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
        ButtonListener.Lives = ButtonListener.Lives_max;
        MoveCoordinator._instance.ball.transform.SetSiblingIndex(1);
        VorotaCollider.isGoal = false;

        menu.SetActive(false);
    }





    public static void OnReturn()
    {
        _instance.menuButtonsPanel.SetActive(true);
        _instance.menu.SetActive(true);
        GameCoordinator.UpdateState(GameCoordinator.GameStates.Pause);
    }

    

}
