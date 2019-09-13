using Dialogs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{

    public static event Action PurchaseSuccess;
    public static event Action UpdateUIEvent;
    public enum TypeItem
    {
        Weapon = 0,
        Bullet = 1,
        Life = 2
    };

    public TypeItem type;
    public Image Icon;
    public int Price;
    public int Damage;
    public int Count;
    public int index_weapon;
    public Text CharacterT;
    public Text PriceT;

    private void Awake()
    {
        UpdateUIEvent += UpdateData;
        UpdateData();
    }

    public void UpdateData()
    {
        switch (type)
        {
            case TypeItem.Bullet:
                CharacterT.text = "Add Bullet " + Count;
                break;
            case TypeItem.Life:
                CharacterT.text = "Add Life " + Count;
                break;
            case TypeItem.Weapon:
                CharacterT.text = "Damage = " + Damage;
                var index = DialogShop.DataItems.BuyItems.IndexOf(index_weapon);
                if (index != -1)
                {
                    GetComponent<Image>().color = new Color32(5,253,59,120);
                }
                if (PlayerPrefs.HasKey(Constant.KEY_WEAPON))
                {
                    int ind = PlayerPrefs.GetInt(Constant.KEY_WEAPON);
                    if(ind == index_weapon)
                    {
                        GetComponent<Image>().color = new Color32(179, 83, 45, 120);
                    }
                }

                break;
        }
        PriceT.text = Price.ToString();
    }

    public void OnCLick()
    {
        if (PlayerPrefs.HasKey(Constant.KEY_MONEY))
        {
            int money = PlayerPrefs.GetInt(Constant.KEY_MONEY);

            if (money < Price && type != TypeItem.Weapon)
            {
                DialogController.Instance.ShowDialog("Ads");
                return;
            }
                
            switch (type)
            {
                case TypeItem.Bullet:
                    if (PlayerPrefs.HasKey(Constant.KEY_COUNT_BULLET))
                    {
                        int count = PlayerPrefs.GetInt(Constant.KEY_COUNT_BULLET);
                        count += Count;
                        PlayerPrefs.SetInt(Constant.KEY_COUNT_BULLET, count);
                    }
                    else
                    {
                        int count = 5;
                        count += Count;
                        PlayerPrefs.SetInt(Constant.KEY_COUNT_BULLET, count);
                    }
                    break;
                case TypeItem.Life:
                    if (PlayerPrefs.HasKey(Constant.KEY_COUNT_LIFE))
                    {
                        int count = PlayerPrefs.GetInt(Constant.KEY_COUNT_LIFE);
                        count += Count;
                        PlayerPrefs.SetInt(Constant.KEY_COUNT_LIFE, count);
                    }
                    else
                    {
                        int count = 5;
                        count += Count;
                        PlayerPrefs.SetInt(Constant.KEY_COUNT_LIFE, count);
                    }
                    break;
                case TypeItem.Weapon:
                    var index = DialogShop.DataItems.BuyItems.IndexOf(index_weapon);
                    if (index != -1)
                    {
                        PlayerPrefs.SetInt(Constant.KEY_WEAPON, index_weapon);
                        UpdateUIEvent?.Invoke();
                        return;
                    }
                    else
                    {
                        if (money < Price)
                        {
                            DialogController.Instance.ShowDialog("Ads");
                            return;
                        }
                        PlayerPrefs.SetInt(Constant.KEY_WEAPON, index_weapon);
                        DialogShop.DataItems.BuyItems.Add(index_weapon);
                        string json = JsonUtility.ToJson(DialogShop.DataItems);
                        PlayerPrefs.SetString(Constant.KEY_BUY_ITEM, json);
                    }
                    break;
            }
            money -= Price;
            PlayerPrefs.SetInt(Constant.KEY_MONEY, money);
            PurchaseSuccess?.Invoke();
            UpdateData();
        }
        else
        {
            PlayerPrefs.SetInt(Constant.KEY_MONEY, 0);
            DialogController.Instance.ShowDialog("Ads");
        }
    }
    private void OnDestroy()
    {
        UpdateUIEvent -= UpdateData;
    }
}
