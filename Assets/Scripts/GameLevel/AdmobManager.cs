﻿//using System;
//using UnityEngine;
//using GoogleMobileAds.Api;
//using System.Drawing;
//using UnityEngine.UIElements;

//public class AdmobManager : MonoBehaviour
//{
//    private BannerView bannerView;

//    public void Start()
//    {
//#if UNITY_ANDROID
//                string appId = "ca-app-pub-3940256099942544~3347511713";
//#elif UNITY_IPHONE
//                    string appId = "ca-app-pub-3940256099942544~1458002511";
//#else
//        string appId = "unexpected_platform";
//#endif

//        // Initialize the Google Mobile Ads SDK.
//        MobileAds.Initialize(appId);

//        this.RequestBanner();
//    }

//    private void RequestBanner()
//    {
//#if UNITY_ANDROID
//                string adUnitId = "ca-app-pub-9641761367991405/7568414311";
//#elif UNITY_IPHONE
//                    string adUnitId = "ca-app-pub-3940256099942544/2934735716";
//#else
//        string adUnitId = "unexpected_platform";
//#endif

//        // Create a 320x50 banner at the top of the screen.
//        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

//        // Create an empty ad request.
//        AdRequest request = new AdRequest.Builder().Build();

//        // Load the banner with the request.
//        this.bannerView.LoadAd(request);
//    }

//    public void ShowBanner()
//    {
//        bannerView.Show();
//    }
//}