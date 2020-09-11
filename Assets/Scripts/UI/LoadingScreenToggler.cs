using System;
using Ads;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LoadingScreenToggler : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingScreen;
        [SerializeField] private UnityAds _adsManager;

        private void OnEnable()
        {
            _adsManager.OnAdsInitialized += ToggleOffLoadingScreen;
        }

        private void ToggleOffLoadingScreen()
        {
            _loadingScreen.SetActive(false);
        }

        private void OnDisable()
        {
            _adsManager.OnAdsInitialized -= ToggleOffLoadingScreen;
        }
    }
}