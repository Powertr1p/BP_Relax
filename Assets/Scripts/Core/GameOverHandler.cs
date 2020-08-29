using System;
using System.Collections;
using Ads;
using PlayerInput;
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

        public event Action OnGameOver;

        private void Awake()
        {
            _timeCounter = GetComponent<TimeCounter>();
        }

        private void Start()
        {
            Advertisement.AddListener(this);
        }

        private void OnEnable()
        {
            _timeCounter.OnTimeIsUp += ToggleGameOver;
        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            switch (showResult)
            {
                case ShowResult.Finished:
                    ApplicationStateHandler.TrackPlayerFocus = false;
                    Restart();
                    break;
                case ShowResult.Skipped:
                    ApplicationStateHandler.TrackPlayerFocus = false;
                    Restart();
                    break;
                default:
                    Debug.LogError("Error with shown ads");
                    break;
            }
        }

        public void ShowAdsAndRestart()
        {
            ApplicationStateHandler.TrackPlayerFocus = false;
            RegularAds.ShowAds();
        }
        
        private void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void ToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
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
        }

        public void OnUnityAdsDidStart(string placementId)
        {
        }
    }
}
