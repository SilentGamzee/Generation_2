using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingController : MonoBehaviour
{
    public RectTransform rectGirl;
    public bool rightMove;

    void Update()
    {
        if(rectGirl.anchoredPosition.x <= -350f)
        {
            rightMove = true;
        }
        if(rectGirl.anchoredPosition.x >= 350f)
        {
            rightMove = false;
        }

        if (rightMove)
        {
            rectGirl.anchoredPosition += new Vector2(320f * Time.deltaTime, rectGirl.anchoredPosition.y);
        }
        else
        {
            rectGirl.anchoredPosition -= new Vector2(320f * Time.deltaTime, rectGirl.anchoredPosition.y);
        }
    }
}
