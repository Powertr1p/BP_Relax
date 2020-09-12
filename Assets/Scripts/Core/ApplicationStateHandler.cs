using System;
using UI;
using UnityEngine;

namespace Core
{
    public class ApplicationStateHandler : MonoBehaviour
    {
        [SerializeField] private GamePause _pauseMenu;
        
        
        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus)
                _pauseMenu.ToggleOnPausePanel();
        }
    }
}