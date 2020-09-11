using System;
using Ads;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour, IUnityAdsListener
    {
        [SerializeField] private GameObject _creditsPanel;
        
        private bool _isCreditsOpen; 
        
        private void Start()
        {
            Advertisement.AddListener(this);
            StartCoroutine(BannerAds.ShowBanner());
        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            switch (showResult)
            {
                case ShowResult.Finished:
                case ShowResult.Skipped:
                    LoadGame();
                    break;
                case ShowResult.Failed:
                    LoadGame();
                    break;
                default:
                    LoadGame();
                    break;
            }
        }
        
        public void OnUnityAdsReady(string placementId)
        {
        }

        public void OnUnityAdsDidError(string message)
        {
            LoadGame();
        }

        public void OnUnityAdsDidStart(string placementId)
        {
        }

        public void ShowAdsAndLoadGame()
        {
            RegularAds.ShowAds();
        }
        
        
        public void ShowCredits()
        {
            _creditsPanel.SetActive(!_isCreditsOpen);
            _isCreditsOpen = !_isCreditsOpen;
        }
        
        private void LoadGame()
        {
            Advertisement.Banner.Hide();
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }

        private void OnDisable()
        {
            Advertisement.RemoveListener(this);
        }
    }
}