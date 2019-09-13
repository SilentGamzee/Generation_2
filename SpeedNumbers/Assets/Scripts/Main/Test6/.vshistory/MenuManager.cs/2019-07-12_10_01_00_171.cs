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
    public GameObject gameModePanel;
    public GameObject hardChoosePanel;
    public Button easyButton;
    public Button normalButton;
    public Button hardButton;
    public List<Button> returnButtons;
    public Button standartButton;
    public Button marksButton;
    public Button difficultSettingButton;
    public GameObject sure_panel;

    public GameObject menu;

    private static MenuManager _instance;
    void Start()
    {
        _instance = this;
        startButton.onClick.AddListener(OnStart);
        exitButton.onClick.AddListener(OnExit);
        easyButton.onClick.AddListener(OnEasy);
        normalButton.onClick.AddListener(OnNormal);
        hardButton.onClick.AddListener(OnHard);
        foreach (var butt in returnButtons)
            butt.onClick.AddListener(OnReturn);

        standartButton.onClick.AddListener(OnStandart);
        marksButton.onClick.AddListener(OnMarks);
        difficultSettingButton.onClick.AddListener(OnDifficult);

        OnReturn();
    }

    void OnDifficult()
    {
        menuButtonsPanel.SetActive(false);
        gameModePanel.SetActive(false);
        hardChoosePanel.SetActive(true);
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
        hardChoosePanel.SetActive(false);
        PlayerManager.IsStandart = true;
        MoveCoordinator.P = 0;

        MoveCoordinator.ResetPosition();
        GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
        ButtonListener.Lives = ButtonListener.Lives_max;
        MoveCoordinator._instance.ball.transform.SetSiblingIndex(1);
        BallCollider.isGoal = false;

        menu.SetActive(false);
    }

    void OnMarks()
    {
        menuButtonsPanel.SetActive(false);
        gameModePanel.SetActive(false);
        hardChoosePanel.SetActive(false);
        PlayerManager.IsStandart = false;
        MoveCoordinator.P = 0;

        MoveCoordinator.ResetPosition();
        GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
        ButtonListener.Lives = ButtonListener.Lives_max;
        MoveCoordinator._instance.ball.transform.SetSiblingIndex(1);
        BallCollider.isGoal = false;

        menu.SetActive(false);
    }


    void OnEasy()
    {
        PlayerManager.HardMode = PlayerManager.hardmodes.Easy;
        OnReturn();
    }

    void OnNormal()
    {
        PlayerManager.HardMode = PlayerManager.hardmodes.Normal;
        OnReturn();
    }

    void OnHard()
    {
        PlayerManager.HardMode = PlayerManager.hardmodes.Hard;
        OnReturn();
    }

    public static void OnReturn()
    {
        _instance.menuButtonsPanel.SetActive(true);
        _instance.gameModePanel.SetActive(false);
        _instance.hardChoosePanel.SetActive(false);
        _instance.menu.SetActive(true);
        GameCoordinator.UpdateState(GameCoordinator.GameStates.Pause);
    }

    

}
