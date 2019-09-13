using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunButton : MonoBehaviour
{
    public weapon weapon_type;
    public float reloadTime;
    public float reload = 0;

    enum weapon
    {
        gun_1,
        gun_2,
        gun_3
    }

    Button button;
    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        reload = reloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
