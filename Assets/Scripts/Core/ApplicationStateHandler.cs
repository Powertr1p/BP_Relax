using System;
using UI;
using UnityEngine;

namespace Core
{
    public class ApplicationStateHandler : MonoBehaviour
    {
        [SerializeField] private GamePause _pauseMenu;

        public static bool TrackPlayerFocus { get; set; }
        
        private void OnApplicationFocus(bool hasFocus)
        {
            if (!TrackPlayerFocus) return;

            if (!hasFocus)
                _pauseMenu.ToggleOnPausePanel();
        }
    }
}