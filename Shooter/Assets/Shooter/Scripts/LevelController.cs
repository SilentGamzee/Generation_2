using Dialogs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : Singleton<LevelController>
{
    //PUBLIC VARIABLES

    public Transform BulletContent;
    public List<Enemy> Enemys;
    public int Life = 5;
    public int Bullet = 5;
    public int complexity = 0;
    public float Damage = 0.5f;
    public List<Weapon> WeaponsData;
    public Image WeaponUi;
    public Text LifeT;
    public Text DamageT;
    public Text CountBulletT;
    public Text BulletT;
    public Text MoneyT;
    public int money = 0;
    public GameObject RechargeButton;
    public GameObject BulletPrefab;

    //PRIVATE VARIABLES
    private List<GameObject> Bullets = new List<GameObject>();
    private int maxBullet = 0;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(Constant.KEY_MONEY))
            money = PlayerPrefs.GetInt(Constant.KEY_MONEY);
        else
            PlayerPrefs.SetInt(Constant.KEY_MONEY, money);

        if (PlayerPrefs.HasKey(Constant.KEY_COUNT_BULLET))
            Bullet = PlayerPrefs.GetInt(Constant.KEY_COUNT_BULLET);
        else
            PlayerPrefs.SetInt(Constant.KEY_COUNT_BULLET, Bullet);

        maxBullet = Bullet;
        CountBulletT.text = Bullet.ToString();
        BulletT.text = Bullet.ToString() + "/" + Bullet.ToString();
        MoneyT.text = money.ToString();
        if (PlayerPrefs.HasKey(Constant.KEY_WEAPON))
        {
            int index_weapon = PlayerPrefs.GetInt(Constant.KEY_WEAPON);
            Damage = WeaponsData[index_weapon].Damage;
            WeaponUi.sprite = WeaponsData[index_weapon].Icon;
        }
        else
        {
            Damage = 0.5f;
        }

        DamageT.text = Damage.ToString();

        if (PlayerPrefs.HasKey(Constant.KEY_COMPLEXITY))
        {
            complexity = PlayerPrefs.GetInt(Constant.KEY_COMPLEXITY);
        }
        else
        {
            complexity = 0;
            PlayerPrefs.SetInt(Constant.KEY_COMPLEXITY, complexity);
        }

        if (PlayerPrefs.HasKey(Constant.KEY_COUNT_LIFE))
            Life = PlayerPrefs.GetInt(Constant.KEY_COUNT_LIFE);
        else
            PlayerPrefs.SetInt(Constant.KEY_COUNT_LIFE, Life);

        for (int i = 0; i < Enemys.Count; i++)
        {
            Enemys[i].Damage += Enemy_Damage;
        }

        for (int i = 0; i < 6; i++)
        {
            Bullets.Add(Instantiate(BulletPrefab, BulletContent));
        }
        LifeT.text = Life.ToString();

        StartCoroutine(WaitStart());
    }

    private IEnumerator WaitStart()
    {
        for (int i = 0; i < Enemys.Count; i++)
        {
            float waiting = UnityEngine.Random.Range(1.0f, 4.0f);
            yield return new WaitForSecondsRealtime(waiting);
            Enemys[i].biggest = true;
        }
    }

    private void Enemy_Damage()
    {
        if (Life > 0)
            Life--;

        if (Life == 0)
            DialogController.Instance.ShowDialog("Lose");

        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if (Bullet > 0)
                Bullet--;

            if (Bullet <= 0)
            {
                RechargeButton.SetActive(true);
            }
            UpdateUI();
        }
    }

    public void ExitMainScene()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public IEnumerator UpdateCoroutine()
    {
        for (int i = 0; i < Bullets.Count; i++)
        {
            if (i < Bullet)
                Bullets[i].SetActive(true);
            else
                Bullets[i].SetActive(false);
        }

        LifeT.text = Life.ToString();
        int currentBullet = Mathf.Clamp(Bullet, 0, maxBullet);
        BulletT.text = currentBullet + "/" + maxBullet;
        MoneyT.text = money.ToString();
        yield return null;
    }

    public void UpdateUI()
    {
        StartCoroutine(UpdateCoroutine());
    }

    public void Restart()
    {
        Life = PlayerPrefs.GetInt(Constant.KEY_COUNT_LIFE);
        Bullet = PlayerPrefs.GetInt(Constant.KEY_COUNT_BULLET);
        for (int i = 0; i < Enemys.Count; i++)
        {
            Enemys[i].transform.localScale = new Vector3(0f, 0f);
        }

        UpdateUI();
        StartCoroutine(WaitStart());
    }

    public void Recharge()
    {
        Bullet = PlayerPrefs.GetInt(Constant.KEY_COUNT_BULLET);
        UpdateUI();
        RechargeButton.SetActive(false);
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt(Constant.KEY_MONEY, money);
        for (int i = 0; i < Enemys.Count; i++)
        {
            Enemys[i].Damage -= Enemy_Damage;
        }
    }
}