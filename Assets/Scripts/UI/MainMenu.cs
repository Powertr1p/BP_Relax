using Ads;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour, IUnityAdsListener
    {
        private void Start()
        {
            Advertisement.AddListener(this);
            StartCoroutine(BannerAds.ShowBanner());
        }

        private void LoadGame()
        {
            Advertisement.Banner.Hide();
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }

        public void ShowAdsAndLoadGame()
        {
            RegularAds.ShowAds();
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
                    Debug.LogError("Ad failed");
                    LoadGame();
                    break;
            }
        }
        
        public void OnUnityAdsReady(string placementId)
        {
        }

        public void OnUnityAdsDidError(string message)
        {
        }

        public void OnUnityAdsDidStart(string placementId)
        {
        }

        private void OnDisable()
        {
            Advertisement.RemoveListener(this);
        }
    }
}