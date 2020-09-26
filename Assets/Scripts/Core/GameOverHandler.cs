using System;
using System.Collections;
using Ads;
using PlayerInput;
using PlayerProgress;
using UI.TimeCounter;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

namespace Core
{
    [RequireComponent(typeof(TimeCounter))]
    public class GameOverHandler : MonoBehaviour, IUnityAdsListener
    {
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private TapRaycaster _raycaster;
        [SerializeField] private GameObject _spawner;
        [SerializeField] private GameObject _circleEffect;

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
            Advertisement.AddListener(this);
        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(_sceneIndexToLoadAfterAds);
        }

        public void Restart()
        {
            _sceneIndexToLoadAfterAds = 1;
           
            if (Advertisement.IsReady())
                RegularAds.ShowAds();
            else
                SceneManager.LoadScene(_sceneIndexToLoadAfterAds);
        }

        public void ToMainMenu()
        {
            _sceneIndexToLoadAfterAds = 0;
            
            if (Advertisement.IsReady())
                RegularAds.ShowAds();
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
            Advertisement.RemoveListener(this);
        }
        
        public void OnUnityAdsReady(string placementId)
        {
        }

        public void OnUnityAdsDidError(string message)
        {
            SceneManager.LoadScene(_sceneIndexToLoadAfterAds);
        }

        public void OnUnityAdsDidStart(string placementId)
        {
        }
    }
}
