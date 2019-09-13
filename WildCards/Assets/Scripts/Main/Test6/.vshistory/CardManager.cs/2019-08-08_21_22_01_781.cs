using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public Text progress_text;
    public Image progress_bar;
    public Sprite closed_sprite;
    public List<Sprite> opened_sprites;
    public List<CardObject> cardsList = new List<CardObject>();

    public static CardManager _instance;
    public static int opened;
    public static int need_open;
    public static int 
    void Start()
    {
        _instance = this;
    }

    public static void CloseSprite(CardObject card)
    {
        card.opened = false;
        card.card_image.sprite = _instance.closed_sprite;
    }

    public static void UpdateCardProgress()
    {
        _instance.progress_text.text = opened + "/" + need_open;
        _instance.progress_bar.fillAmount = opened / (float)need_open;
    }


    public static void OpenSprite(CardObject card)
    {
        card.opened = false;
        if (card.card_num >= 0 && card.card_num < _instance.opened_sprites.Count)
            card.card_image.sprite = _instance.opened_sprites[card.card_num];
    }
}
