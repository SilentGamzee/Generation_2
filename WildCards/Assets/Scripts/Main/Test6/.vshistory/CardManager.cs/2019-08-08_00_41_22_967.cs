using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public Sprite closed_sprite;
    public List<Sprite> opened_sprites;

    public static List<CardObject> cardsList = new List<CardObject>();
    public static CardManager _instance;

    void Start()
    {
        _instance = this;
    }

    public static void CloseSprite(CardObject card) => card.card_image.sprite = _instance.closed_sprite;


    public static void OpenSprite()
    {

    }
}
