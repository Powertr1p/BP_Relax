using AppodealAds.Unity.Api;
using UI;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Core
{
    public class ApplicationStateHandler : MonoBehaviour
    {
        [SerializeField] private GamePause _pauseMenu;
        [SerializeField] private GameOverHandler _handler;

        private void OnApplicationFocus(bool hasFocus)
        {
            if (_handler.IsAdShowing) return;
            if (GameStateHandler.CurrentGameState == GameState.GameOver) return;
            
            if (!hasFocus)
                _pauseMenu.ToggleOnPausePanel();
        }
    }
}