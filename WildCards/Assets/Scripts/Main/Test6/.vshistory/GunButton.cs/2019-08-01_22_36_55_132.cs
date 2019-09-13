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
        reload = reloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
