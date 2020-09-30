using System;
using UnityEngine;

namespace UI
{
    public class GamePause : MonoBehaviour
    {
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private GameObject _playerInputHandler;

        public event Action GamePaused;
        public event Action GameUnpaused;
        
        public void ToggleOnPausePanel()
        {
            GamePaused?.Invoke();
            _pausePanel.SetActive(true);
            _playerInputHandler.SetActive(false);
        }

        public void ToggleOffPausePanel()
        {
            GameUnpaused?.Invoke();
            _pausePanel.SetActive(false);
            _playerInputHandler.SetActive(true);
        }
    }
}