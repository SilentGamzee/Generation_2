using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardObject : MonoBehaviour
{
    public int card_num = -1;
    public bool opened = false;

    public Image card_image;

    public static CardObject last_opened;

    private bool isErrorOpen = false;
    void Start()
    {
        card_image = this.GetComponent<Image>();
        this.GetComponent<Button>().onClick.AddListener(OnOpen);
    }

    void OnOpen()
    {
        CardManager.OpenSprite(this);
        if (last_opened == null)
        {
            last_opened = this;
            return;
        }

        if (last_opened.card_num != card_num)
        {
            isErrorOpen = true;
            return;
        }


    }

    public void Close()
    {
        CardManager.CloseSprite(this);
        if (last_opened != null)
            CardManager.CloseSprite(last_opened);
        last_opened = null;
        isErrorOpen = false;
    }

    private float t = 0;
    void Update()
    {
        if (!isErrorOpen) return;
        t += Time.deltaTime;
        if (t < 2f) return;
        t = 0;
        Close();
    }
}
