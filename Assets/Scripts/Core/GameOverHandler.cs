using UI.TimeCounter;
using UnityEngine;

namespace Core
{
    public class GameOverHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private TimeCounter _timeCounter;

        private void OnEnable()
        {
            _timeCounter.OnTimeIsUp += ToggleGameOver;
        }

        private void ToggleGameOver()
        {
            Time.timeScale = 0;
            _gameOverPanel.SetActive(true);
        }
    
        private void OnDisable()
        {
            _timeCounter.OnTimeIsUp -= ToggleGameOver;
        }
    }
}
