using Dialogs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogShop : Dialog
{
    public Transform ShopContent;
    public Text MoneyT;
    public List<ShopItem> shopItems;

    public static DataBuyItem DataItems = new DataBuyItem();

    private int money;
    private void Awake()
    {
        ShopItem.PurchaseSuccess += PurchaseSuccess;
        DialogAds.RewardedSuccess += RewardedSuccess;
        if (PlayerPrefs.HasKey(Constant.KEY_MONEY))
            money = PlayerPrefs.GetInt(Constant.KEY_MONEY);
        else
        {
            money = 0;
            PlayerPrefs.SetInt(Constant.KEY_MONEY, money);
        }
            

        DataItems.BuyItems = new List<int>();
        if(PlayerPrefs.HasKey(Constant.KEY_BUY_ITEM))
            DataItems = JsonUtility.FromJson<DataBuyItem>(PlayerPrefs.GetString(Constant.KEY_BUY_ITEM));

        MoneyT.text = money.ToString();

        for (int i = 0; i < shopItems.Count; i++)
            Instantiate(shopItems[i], ShopContent);
    }

    private void RewardedSuccess()
    {
        UpdateMoney();
    }

    private void PurchaseSuccess()
    {
        UpdateMoney();
        if (PlayerPrefs.HasKey(Constant.KEY_BUY_ITEM))
            DataItems = JsonUtility.FromJson<DataBuyItem>(PlayerPrefs.GetString(Constant.KEY_BUY_ITEM));
    }

    private void UpdateMoney()
    {
        money = PlayerPrefs.GetInt(Constant.KEY_MONEY);
        MoneyT.text = money.ToString();
    }

    private void OnDestroy()
    {
        ShopItem.PurchaseSuccess -= PurchaseSuccess;
        DialogAds.RewardedSuccess -= RewardedSuccess;
    }
}
[Serializable]
public class DataBuyItem
{
    public List<int> BuyItems = new List<int>();
}
