using Assets.Scripts.Main;
using Assets.Scripts.Main.Test6;
using System.Collections;
using System.Collections.Generic;
using Test1;
using UnityEngine;
using UnityEngine.UI;

public class GameEndManager : MonoBehaviour
{
    public Button ok_button;
    public Text coins_text;

    private static GameEndManager _instance;
    void Start()
    {
        _instance = this;
        ok_button.onClick.AddListener(OnOkButton);
    }
    void OnOkButton()
    {
        PanelManager.Get().game_end_panel.SetActive(false);
        PanelManager.Get().city_panel.SetActive(true);
        PanelManager.Get().playground_panel.SetActive(false);
    }
    private static void UpdateWinner()
    {

        PanelManager.Get().game_end_panel.SetActive(false);
    }



    private float t = 0;
    void Update()
    {
        if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.GameEnd) return;
        t += Time.deltaTime;
        if (t < 1.5f) return;
        t = 0;
        
        

        GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
    }
}
