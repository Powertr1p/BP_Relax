using System;
using Core;
using UnityEngine;

namespace PlayerInput
{
    public class TapDetector : MonoBehaviour
    {
        public event Action OnPlayerTap;
        
        private void Update()
        {
            if (GameModeHandler.CurrentGameState == GameState.NormalState)
                if (Input.GetMouseButtonDown(0))
                    OnPlayerTap?.Invoke();
            
            if (GameModeHandler.CurrentGameState == GameState.SlowState)
                if (Input.GetMouseButton(0))
                    OnPlayerTap?.Invoke();
        }
    }
}
