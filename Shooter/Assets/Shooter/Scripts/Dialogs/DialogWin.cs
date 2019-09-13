using Dialogs;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogWin : Dialog
{
    // Start is called before the first frame update
    public Text text;


    public void NextBet()
    {
        Close();
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        Close();
    }
}