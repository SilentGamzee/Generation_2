using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController>
{
    //EVENTS

    public event Action OnGameControllerInited;

    //CONSTANTS

    public const string PLAY_SCENE_KEY = "Game";


    public void StartPlay()
    {
        SceneManager.LoadScene(PLAY_SCENE_KEY, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}