using Assets.Korzina.Scripts;
using Dialogs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : Singleton<LevelController>
{
    public RectTransform rt;
    public Image img;

    public List<Sprite> ImageList;
    public bool moving = false;
    public bool Scored = false;
    private int index = 0;

    private void Awake()
    {
        img.sprite = ImageList[0];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if (!moving)
            {
                moving = true;
                StartCoroutine(FakeAddForce());
            }
        }
    }

    IEnumerator FakeAddForce()
    {
        Scored = false;
        float time = 0f;
        float i = 0.01f;
        while (moving)
        {
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, rt.anchoredPosition.y + 750f * Time.deltaTime);
            time += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }

    public void ExitMainScene()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void Restart()
    {
        moving = false;
        rt.anchoredPosition = new Vector2(0, 200f);
        if (Scored)
            NextImage();
        else
            PreviousImage();
    }



    public void NextImage()
    {
        if(index + 1 < ImageList.Count)
        {
            index++;
            var tier_obj = new TierObject(index);
            img.sprite = ImageList[index];
        }
    }

    public void PreviousImage()
    {
        if (index >= 1)
        {
            index--;
            img.sprite = ImageList[index];
        }
    }
}