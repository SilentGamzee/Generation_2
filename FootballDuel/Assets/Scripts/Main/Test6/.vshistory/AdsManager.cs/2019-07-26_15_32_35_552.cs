﻿using GoogleMobileAds.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Main.Test6
{
    public class AdsManager:MonoBehaviour
    {
        public static event Action RewardedSuccess;
        public Button adsButton;

        public enum StateAds
        {
            Closed = 0,
            AdLoaded = 1,
            Skip = 2
        }

        public Image RewardedButton;

        private StateAds stateAds;
        private RewardedAd rewardedAd;
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
            PlayerManager.Points += 500;
            Debug.LogError("GetEarnedReward: End");
        }

        private void OnDestroy()
        {
            rewardedAd.OnAdLoaded -= HandleRewardedAdLoaded;
            rewardedAd.OnUserEarnedReward -= HandleUserEarnedReward;
            rewardedAd.OnAdClosed -= HandleRewardedAdClosed;
        }

    }
}
