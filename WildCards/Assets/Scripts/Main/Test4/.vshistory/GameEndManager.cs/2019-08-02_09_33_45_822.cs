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
    public Text wave_counter;

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

    public static void OnWaveCounter()
    {
        _instance.wave_counter.text = EnemySpawner.spawn_count + "/" + HardModeButton.static_wave_count;
    }

    private static void UpdateWinner()
    {
        _instance.coins_text.text = "" + MoveCoordinator.P;
        PanelManager.Get().game_end_panel.SetActive(true);
        PlayerManager.Points += MoveCoordinator.P;
        MoveCoordinator.P = 0;
    }

    void Update()
    {
        if (GameCoordinator.GetGameState() != GameCoordinator.GameStates.GameEnd) return;
        UpdateWinner();
        GameCoordinator.UpdateState(GameCoordinator.GameStates.WaitingToStart);
    }
}
