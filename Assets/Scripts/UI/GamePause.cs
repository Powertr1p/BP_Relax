using System;
using UnityEngine;

namespace UI
{
    public class GamePause : MonoBehaviour
    {
        [SerializeField] private GameObject _pausePanel;

        public event Action GamePaused;
        public event Action GameUnpaused;
        
        public void ToggleOnPausePanel()
        {
            GamePaused?.Invoke();
            _pausePanel.SetActive(true);
        }

        public void ToggleOffPausePanel()
        {
            GameUnpaused?.Invoke();
            _pausePanel.SetActive(false);
        }
    }
}