using Dialogs;
using UnityEngine;

public class MainSceneController : MonoBehaviour
{
    public void PlayGame()
    {
        GameController.Instance.StartPlay();
    }

    public void ShowSettings()
    {
        DialogController.Instance.ShowDialog("Settings");
    }
    public void ShowShop()
    {
        DialogController.Instance.ShowDialog("Shop");
    }

    public void ExitGame()
    {
        DialogController.Instance.ShowDialog("Quit");
    }
}