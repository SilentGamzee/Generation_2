using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunButton : MonoBehaviour
{
    public GameObject bullet_prefab;
    public float reloadTime;
    public float reload = 0;

    Button button;
    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (reload > 0) return;
        reload = reloadTime - PlayerManager.player_switch_lvl/100f;
        Instantiate(bullet_prefab, this.transform);
    }

    void Update()
    {
        if (reload <= 0) return;
        reload -= Time.deltaTime;
    }
}
