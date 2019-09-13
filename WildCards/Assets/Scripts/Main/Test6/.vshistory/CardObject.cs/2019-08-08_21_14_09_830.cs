using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardObject : MonoBehaviour
{
    public int card_num = -1;
    public bool opened = false;

    public Image card_image;

    private static CardObject last_opened;
    private static bool isErrorOpen = false;

    private bool isThisErrorOpened = false;

    void Start()
    {
        card_image = this.GetComponent<Image>();
        this.GetComponent<Button>().onClick.AddListener(OnOpen);
    }

    void OnOpen()
    {
        if (opened || isErrorOpen) return;
        CardManager.OpenSprite(this);
        if (last_opened == null)
        {
            last_opened = this;
            return;
        }

        if (last_opened.card_num != card_num)
        {
            isErrorOpen = true;
            isThisErrorOpened = true;
            return;
        }
        CardManager.opened++;
        CardManager.UpdateCardProgress();
        last_opened = null;
    }

    public void Close()
    {
        CardManager.CloseSprite(this);
        CardManager.CloseSprite(last_opened);
        last_opened = null;
        isErrorOpen = false;
        isThisErrorOpened = false;
    }

    private static float t = 0;
    void Update()
    {
        if (!isThisErrorOpened) return;
        t += Time.deltaTime;
        if (t < 4f) return;
        t = 0;
        Close();
    }
}
