using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndManager : MonoBehaviour
{
    public GameObject resetButton;

    void Update()
    {
        resetButton.SetActive(GameCoordinator.GetGameState() != GameCoordinator.GameStates.GameEnd);
    }
}
