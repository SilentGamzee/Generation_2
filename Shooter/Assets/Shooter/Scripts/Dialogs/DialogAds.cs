using Dialogs;
using GoogleMobileAds.Api;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogAds : Dialog
{
    public static event Action RewardedSuccess;

    public enum StateAds
    {
        Closed = 0,
        AdLoaded = 1,
        Skip = 2
    }

    public Image RewardedButton;

    private StateAds stateAds;
    private RewardedAd rewardedAd;
    private int rewardedMoney = 50;
    private bool earnedReward = false;

    private void Awake()
    {
        stateAds = StateAds.Skip;
        MobileAds.Initialize("ca-app-pub-9522487018415125~6600859414");
        CreateAndLoadRewardedAd();
    }

    private void Update()
    {
        switch (stateAds)
        {
            case StateAds.AdLoaded:
                RewardedButton.color = new Color(1f, 1f, 1f, 1f);
                stateAds = StateAds.Skip;
                break;
            case StateAds.Closed:
                RewardedButton.color = new Color(1f, 1f, 1f, 0.5f);
                CreateAndLoadRewardedAd();
                stateAds = StateAds.Skip;
                break;
            case StateAds.Skip:
                break;
        }

        if (earnedReward)
        {
            GetEarnedReward();
            earnedReward = false;
        }
    }

    private void CreateAndLoadRewardedAd()
    {
        Debug.LogError("CreateAndLoadAD");
        rewardedAd = new RewardedAd("ca-app-pub-3940256099942544/5224354917");
        rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request);
    }

    private void HandleRewardedAdClosed(object sender, EventArgs e)
    {
        Debug.LogError("AdClosed");
        stateAds = StateAds.Closed;
    }

    private void HandleUserEarnedReward(object sender, Reward e)
    {
        Debug.LogError("AdEarnedReward");
        earnedReward = true;
    }

    private void HandleRewardedAdLoaded(object sender, EventArgs e)
    {
        Debug.LogError("AdLoaded");
        stateAds = StateAds.AdLoaded;
    }

    public void Start_AD()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
    }

    private void GetEarnedReward()
    {
        Debug.LogError("GetEarnedReward: Start");
        int money = 0;
        if (PlayerPrefs.HasKey(Constant.KEY_MONEY))
            money = PlayerPrefs.GetInt(Constant.KEY_MONEY);

        money += rewardedMoney;
        PlayerPrefs.SetInt(Constant.KEY_MONEY, money);
        RewardedSuccess?.Invoke();
        Debug.LogError("GetEarnedReward: End");
    }

    private void OnDestroy()
    {
        rewardedAd.OnAdLoaded -= HandleRewardedAdLoaded;
        rewardedAd.OnUserEarnedReward -= HandleUserEarnedReward;
        rewardedAd.OnAdClosed -= HandleRewardedAdClosed;
    }
}