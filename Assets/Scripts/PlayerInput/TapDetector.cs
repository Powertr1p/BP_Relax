using System;
using Core;
using UnityEngine;

namespace PlayerInput
{
    public class TapDetector : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        public event Action OnPlayerTap;
        
        private void Update()
        {
            if (GameStateHandler.CurrentGameState == GameState.NormalState)
                if (Input.GetMouseButtonDown(0))
                    OnPlayerTap?.Invoke();
            
            if (GameStateHandler.CurrentGameState == GameState.SlowState)
                if (Input.GetMouseButton(0))
                    OnPlayerTap?.Invoke();
        }

        public Vector3 GetTapPosition()
        {
            return _camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
