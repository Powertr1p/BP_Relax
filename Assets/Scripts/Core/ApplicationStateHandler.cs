using UI;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Core
{
    public class ApplicationStateHandler : MonoBehaviour
    {
        [SerializeField] private GamePause _pauseMenu;

        private void OnApplicationFocus(bool hasFocus)
        {
            if (GameStateHandler.CurrentGameState == GameState.GameOver) return;
            
            if (!hasFocus)
                _pauseMenu.ToggleOnPausePanel();
        }
    }
}