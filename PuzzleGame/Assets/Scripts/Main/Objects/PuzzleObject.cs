using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleObject : MonoBehaviour
{
    public int id;
    private static PuzzleObject lastPuzzle;
    
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnPuzzleClick);
    }

    void OnPuzzleClick()
    {
        if (GameCoordinator.GetGameState() == GameCoordinator.GameStates.GameEnd) return;
        if (lastPuzzle == null)
        {
            lastPuzzle = this;
            PuzzleManager.ShowChooser(this);
            return;
        }
        var x = this.transform.position;
        this.transform.position = lastPuzzle.transform.position;
        lastPuzzle.transform.position = x;


        PuzzleManager.HideChooser();
        lastPuzzle = null;

        PuzzleManager.CheckWin();
    }



}
