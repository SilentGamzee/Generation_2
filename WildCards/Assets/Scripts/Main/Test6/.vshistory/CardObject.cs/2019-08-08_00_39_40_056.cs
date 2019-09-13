using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardObject : MonoBehaviour
{
    public int card_num = -1;
    public bool opened = false;

    public Image card_sprite;

    public static CardObject last_opened;

    private bool isErrorOpen = false;
    void Start()
    {
        if (!CardManager.cardsList.Contains(this))
            CardManager.cardsList.Add(this);
        card_sprite = this.GetComponent<Image>();
        this.GetComponent<Button>().onClick.AddListener(OnOpen);
    }

    void OnOpen()
    {
        opened = true;
        if (last_opened == null)
        {
            last_opened = this;
            return;
        }

        last_opened = null;
    }

    public void Close()
    {

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
