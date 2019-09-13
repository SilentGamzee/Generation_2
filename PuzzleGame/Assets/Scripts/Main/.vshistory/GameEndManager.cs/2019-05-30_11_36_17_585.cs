using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndManager : MonoBehaviour
{
    public GameObject resetButton;




    void Update()
    {
        var isGameEnd = GameCoordinator.GetGameState() == GameCoordinator.GameStates.GameEnd;
        resetButton.SetActive(isGameEnd);
        if (!isGameEnd) return;

        
    }
}
