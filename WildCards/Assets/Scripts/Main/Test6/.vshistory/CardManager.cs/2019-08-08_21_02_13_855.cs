using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public Sprite closed_sprite;
    public List<Sprite> opened_sprites;
    public List<CardObject> cardsList = new List<CardObject>();

    public static CardManager _instance;
    public static int opened;
    public static int need_open;
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

    }


    public static void OpenSprite(CardObject card)
    {
        card.opened = false;
        if (card.card_num >= 0 && card.card_num < _instance.opened_sprites.Count)
            card.card_image.sprite = _instance.opened_sprites[card.card_num];
    }
}
