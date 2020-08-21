using System;
using System.Collections;
using PlayerInput;
using UI.TimeCounter;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    [RequireComponent(typeof(TimeCounter))]
    public class GameOverHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private TapRaycaster _raycaster;
        [SerializeField] private GameObject _spawner;
        
        private TimeCounter _timeCounter;

        public event Action OnGameOver;

        private void Awake()
        {
            _timeCounter = GetComponent<TimeCounter>();
        }

        private void OnEnable()
        {
            _timeCounter.OnTimeIsUp += ToggleGameOver;
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void ToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        private void ToggleGameOver()
        {
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
    }
}
