using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool _pressed = false;
    private GameObject hero;
    void Start()
    {
        hero = ButtonListener._instance.myhero;
    }

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

        var pos = Camera.current.WorldToScreenPoint(Input.mousePosition);
        var target = hero.transform.position;
        if(pos.y>0)
        target.y += 1;
        hero.transform.position = Vector3.MoveTowards(hero.transform.position, target, Time.deltaTime);

    }
}
