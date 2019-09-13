using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool _pressed = false;
    public bool isButtonDown;
    private GameObject hero;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        _pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pressed = false;
    }

    void Update()
    {
        if (!_pressed) return;
        if (hero == null)
            hero = ButtonListener._instance.myhero;
        
        var target = hero.transform.position;
        if (isButtonDown)
            target.y -= 1;
        else
            target.y += 1;
        hero.transform.position = Vector3.MoveTowards(hero.transform.position, target, Time.deltaTime*2f * (PlayerManager.player_speed_lvl+1));

    }
}
