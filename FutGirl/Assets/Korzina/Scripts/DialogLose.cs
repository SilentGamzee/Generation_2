using Dialogs;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogLose : Dialog
{

    public void Restart()
    {
        Close();
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        Close();
    }
}