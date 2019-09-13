using Dialogs;
using UnityEngine.SceneManagement;

public class DialogLose : Dialog
{
    private void Awake()
    {
        for (int i = 0; i < LevelController.Instance.Enemys.Count; i++)
        {
            LevelController.Instance.Enemys[i].biggest = false;
        }
    }

    public void Restart()
    {
        LevelController.Instance.Restart();
        Close();
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        Close();
    }
}