using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public Image progress_bar;
    public Text progress_text;
    public GameObject chooser;
    public List<PuzzleObject> puzzles;

    public static List<Vector3> initPoses = new List<Vector3>();
    public static bool IsPlaying = false;
    public static float time;
    public static float total_time;
    public static PuzzleManager _instance;


    void Start()
    {
        _instance = this;
        puzzles.ForEach(x => initPoses.Add(x.transform.position));
    }

    public static void ShowChooser(PuzzleObject puzzle)
    {
        _instance.chooser.transform.position = puzzle.transform.position;
        _instance.chooser.gameObject.SetActive(true);
    }

    public static void HideChooser()
    {
        _instance.chooser.gameObject.SetActive(false);
    }

    public static void CheckWin()
    {
        var win = true;
        foreach (var puzzle in _instance.puzzles)
            if (puzzle.transform.position != initPoses[puzzle.id]) win = false;

        if (win)
        {
            PlayerManager.P = 100 * LevelManager.current_lvl + 100 * PlayerManager.player_training_lvl;
            GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);
            PuzzleManager.IsPlaying = false;
        }
    }

    public static void UpdateProgress()
    {
        _instance.progress_bar.fillAmount = time / total_time;
        _instance.progress_text.text = (int)time + "/" + (int)total_time;
    }

    void Update()
    {
        if (!IsPlaying) return;
        time += Time.deltaTime;
        UpdateProgress();
        if (time >= total_time)
        {
            PlayerManager.P = 0;
            GameCoordinator.UpdateState(GameCoordinator.GameStates.GameEnd);
        }
    }
}
