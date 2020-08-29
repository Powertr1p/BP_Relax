using System;
using Core;
using UnityEngine;

namespace PlayerInput
{
    public class TapDetector : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _holdTimeToSuccess = 3f;
        public event Action<Vector3> OnPlayerTap;
        public event Action OnLongTapSuccess;
        public event Action LongTouchContinue;
        public event Action LongTouchCanceled;

        private float _lastTimePresses;
        private float _pressingTime;
        private bool _isPressing;
        private bool _isLongTouchSuccessfull;
        
        private void Update()
        {
            if (GameStateHandler.CurrentGameState == GameState.NormalState)
                for (int i = 0; i < Input.touchCount; i++)
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                        OnPlayerTap?.Invoke(_camera.ScreenToWorldPoint(Input.touches[i].position));
            
            if (GameStateHandler.CurrentGameState == GameState.SlowState)
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                    OnPlayerTap?.Invoke(GetTapPosition());
            
            CheckForLongTap();
        }

        public Vector3 GetTapPosition()
        {
            return _camera.ScreenToWorldPoint(Input.GetTouch(0).position);
        }

        private void CheckForLongTap()
        {
            if (GameStateHandler.CurrentGameState == GameState.SlowState || Input.touchCount < 1) return;

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                _isPressing = true;
                _lastTimePresses = Time.time;
            }

            if (_isPressing)
            {
                _pressingTime = Time.time - _lastTimePresses;

                if (_pressingTime > 0.5f)
                    LongTouchContinue?.Invoke();

                if (_pressingTime >= _holdTimeToSuccess)
                {
                    OnLongTapSuccess?.Invoke();
                    _isLongTouchSuccessfull = true;
                    _isPressing = false;
                }
            }
            
            if (Input.GetTouch(0).phase == TouchPhase.Ended && !_isLongTouchSuccessfull)
            {
                LongTouchCanceled?.Invoke();
                _isPressing = false;
                _isLongTouchSuccessfull = false;
            }
        }
    }
}
