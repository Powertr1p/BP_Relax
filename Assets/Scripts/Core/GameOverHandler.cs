using System;
using System.Collections;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using PlayerInput;
using UI.TimeCounter;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    [RequireComponent(typeof(TimeCounter))]
    public class GameOverHandler : MonoBehaviour, IInterstitialAdListener
    {
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private TapRaycaster _raycaster;
        [SerializeField] private GameObject _spawner;
        [SerializeField] private GameObject _circleEffect;

        public event Action OnAdsFinish;
        
        private TimeCounter _timeCounter;
        private int _sceneIndexToLoadAfterAds;

        public event Action OnGameOver;

        private void Awake()
        {
            _timeCounter = GetComponent<TimeCounter>();
            Appodeal.setInterstitialCallbacks(this);
        }

        private void OnEnable()
        {
            _timeCounter.OnTimeIsUp += ToggleGameOver;
        }

        public void Restart()
        {
            _sceneIndexToLoadAfterAds = 1;
            
            if (Appodeal.canShow(Appodeal.INTERSTITIAL))
                Appodeal.show(Appodeal.INTERSTITIAL);
            else
                SceneManager.LoadScene(_sceneIndexToLoadAfterAds);
        }

        public void ToMainMenu()
        {
            _sceneIndexToLoadAfterAds = 0;
            
            if (Appodeal.isLoaded(Appodeal.INTERSTITIAL))
                Appodeal.show(Appodeal.INTERSTITIAL);
            else
                SceneManager.LoadScene(_sceneIndexToLoadAfterAds);
        }

        private void ToggleGameOver()
        {
            _circleEffect.SetActive(false);
            _raycaster.gameObject.SetActive(false);
            _spawner.SetActive(false);
            OnGameOver?.Invoke();
            
            StartCoroutine(WaitBeforeToggleGameOverPanel());
        }

        private IEnumerator WaitBeforeToggleGameOverPanel()
        {
            yield return new WaitForSecondsRealtime(4f);
            _gameOverPanel.SetActive(true);
        }

        private void OnDisable()
        {
            _timeCounter.OnTimeIsUp -= ToggleGameOver;
        }

        public void onInterstitialLoaded(bool isPrecache)
        {
        }

        public void onInterstitialFailedToLoad()
        {
        }

        public void onInterstitialShowFailed()
        {
        }

        public void onInterstitialShown()
        {
            OnAdsFinish?.Invoke();
            SceneManager.LoadScene(_sceneIndexToLoadAfterAds);
        }

        public void onInterstitialClosed()
        {
            OnAdsFinish?.Invoke();
            SceneManager.LoadScene(_sceneIndexToLoadAfterAds);
        }

        public void onInterstitialClicked()
        {
        }

        public void onInterstitialExpired()
        {
        }
    }
}
