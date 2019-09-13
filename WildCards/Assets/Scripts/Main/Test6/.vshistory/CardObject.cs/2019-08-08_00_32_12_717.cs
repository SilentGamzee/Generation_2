using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardObject : MonoBehaviour
{
    public int card_num = -1;
    public bool opened = false;

    public static CardObject last_opened; 

    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnOpen);
    }

    void OnOpen()
    {
        if(last_opened == null)
        last_opened = this;
        opened = true;
    }

    void Update()
    {

    }
}
