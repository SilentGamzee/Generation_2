using Dialogs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSettings : Dialog
{
    public Text countBullet;
    public Button EasyBtn;
    public Button MiddleBtn;
    public Button HardBtn;
    private static string KEY_COMPLEXITY = "Complexity_key";

    void Awake()
    {
        if (PlayerPrefs.HasKey(KEY_COMPLEXITY))
        {
            int complexity = PlayerPrefs.GetInt(KEY_COMPLEXITY);
            switch (complexity)
            {
                case 0:
                    EasyBtn.Select();
                    EasyBtn.OnSelect(null);
                    break;
                case 1:
                    MiddleBtn.Select();
                    MiddleBtn.OnSelect(null);
                    break;
                case 2:
                    HardBtn.Select();
                    HardBtn.OnSelect(null);
                    break;
            }
        }
        else
        {
            PlayerPrefs.SetInt(KEY_COMPLEXITY, 0);
            EasyBtn.Select();
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        int complexity = PlayerPrefs.GetInt(KEY_COMPLEXITY);
        switch (complexity)
        {
            case 0:
                countBullet.text = "1";
                break;
            case 1:
                countBullet.text = "2";
                break;
            case 2:
                countBullet.text = "3";
                break;
        }
    }

    public void ChangeComplexity(int complexity)
    {
        PlayerPrefs.SetInt(KEY_COMPLEXITY, complexity);
        UpdateUI();
    }
}
