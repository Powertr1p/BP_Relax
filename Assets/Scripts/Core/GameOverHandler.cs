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

        public bool IsAdShowing { get; private set; } 

        public event Action OnAdsFinish;
        
        private TimeCounter _timeCounter;
        private int _sceneIndexToLoadAfterAds;

        public event Action OnGameOver;

        private void Awake()
        {
            _timeCounter = GetComponent<TimeCounter>();
        }

        private void OnEnable()
        {
            _timeCounter.OnTimeIsUp += ToggleGameOver;
        }
        
        private void Start()
        {
            Appodeal.setInterstitialCallbacks(this);
        }

        public void Restart()
        {
            _sceneIndexToLoadAfterAds = 1;

            if (Appodeal.isLoaded(Appodeal.INTERSTITIAL))
            {
                Appodeal.show(Appodeal.INTERSTITIAL);
                IsAdShowing = true;
            }
                
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
            throw new NotImplementedException();
        }

        public void onInterstitialFailedToLoad()
        {
            SceneManager.LoadScene(_sceneIndexToLoadAfterAds);
        }

        public void onInterstitialShowFailed()
        {
            SceneManager.LoadScene(_sceneIndexToLoadAfterAds);
        }

        public void onInterstitialShown()
        {
            OnAdsFinish?.Invoke();
            SceneManager.LoadSceneAsync(_sceneIndexToLoadAfterAds);
            IsAdShowing = false;
        }

        public void onInterstitialClosed()
        {
            IsAdShowing = false;
        }

        public void onInterstitialClicked()
        {
        }

        public void onInterstitialExpired()
        {
        }
    }
}
