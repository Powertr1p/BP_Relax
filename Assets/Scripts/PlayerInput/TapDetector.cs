using System;
using Core;
using UnityEngine;

namespace PlayerInput
{
    public class TapDetector : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        public event Action<Vector3> OnPlayerTap;

        private void Update()
        {
            if (GameStateHandler.CurrentGameState == GameState.NormalState)
                for (int i = 0; i < Input.touchCount; i++)
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                        OnPlayerTap?.Invoke(_camera.ScreenToWorldPoint(Input.touches[i].position));
            
            if (GameStateHandler.CurrentGameState == GameState.SlowState)
                if (Input.GetMouseButton(0))
                    OnPlayerTap?.Invoke(GetTapPosition());
        }

        public Vector3 GetTapPosition()
        {
            return _camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
