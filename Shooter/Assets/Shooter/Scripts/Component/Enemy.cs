using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public event Action Damage;
    public Image img;
    public List<Sprite> NormalList;
    public List<Sprite> KillList;
    public bool biggest = false;
    public float Life;
    private int complexity;
    private int speed;
    private int indexZombie = 0;

    private void Awake()
    {
        indexZombie = UnityEngine.Random.Range(0, NormalList.Count);
        img.sprite = NormalList[indexZombie];
        if (PlayerPrefs.HasKey(Constant.KEY_COMPLEXITY))
        {
            complexity = PlayerPrefs.GetInt(Constant.KEY_COMPLEXITY);
            switch (complexity)
            {
                case 0:
                    Life = 1f;
                    break;
                case 1:
                    Life = 2f;
                    break;
                case 2:
                    Life = 3f;
                    break;
            }
        }
        else
        {
            PlayerPrefs.SetInt(Constant.KEY_COMPLEXITY, 0);
            Life = 1f;
        }

        switch (complexity)
        {
            case 0:
                speed = 6;
                break;
            case 1:
                speed = 4;
                break;
            case 2:
                speed = 2;
                break;
        }

        Damage += Enemy_Damage;
        transform.localScale = new Vector3(0f, 0f);
    }

    private void Enemy_Damage()
    {
        StartCoroutine(waiting());
    }

    private IEnumerator waiting()
    {
        transform.localScale = new Vector3(0f, 0f);
        float waiting = UnityEngine.Random.Range(1.0f, 4.0f);
        yield return new WaitForSecondsRealtime(waiting);
        complexity = PlayerPrefs.GetInt(Constant.KEY_COMPLEXITY);
        switch (complexity)
        {
            case 0:
                Life = 1f;
                break;
            case 1:
                Life = 2f;
                break;
            case 2:
                Life = 3f;
                break;
        }
        biggest = true;
    }

    void Update()
    {
        if (biggest)
        {
            if (transform.localScale.x < 2)
            {
                transform.localScale += new Vector3(Time.deltaTime / 4, Time.deltaTime / 4, 1);
            }
            else
            {
                biggest = false;
                Damage?.Invoke();
            }
        }
    }

    public void Killed()
    {
        if (LevelController.Instance.Bullet >= 0)
        {
            if(LevelController.Instance.Bullet == 0)
                LevelController.Instance.Bullet--;

            Life -= LevelController.Instance.Damage;
            if (Life <= 0)
                StartCoroutine(kill());
        }
    }

    IEnumerator kill()
    {
        biggest = false;
        img.sprite = KillList[indexZombie];
        yield return new WaitForSecondsRealtime(0.5f);
        indexZombie = UnityEngine.Random.Range(0, NormalList.Count);
        img.sprite = NormalList[indexZombie];
        switch (complexity)
        {
            case 0:
                LevelController.Instance.money++;
                break;
            case 1:
                LevelController.Instance.money += 3;
                break;
            case 2:
                LevelController.Instance.money += 5;
                break;
        }
        Enemy_Damage();
    }

    private void OnDestroy()
    {
        Damage -= Enemy_Damage;
    }
}
