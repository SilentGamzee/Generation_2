using UnityEngine;

public class MainSceneController : MonoBehaviour
{
    public void PlayGame()
    {
        GameController.Instance.StartPlay();
    }

    public void ExitGame()
    {
        GameController.Instance.ExitGame();
    }
}