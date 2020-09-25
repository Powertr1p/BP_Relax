using System;
using UnityEngine;

namespace PlayerProgress
{
    public class PlayerLevelProgress : MonoBehaviour //TODO: Delete MonoBehaviour
    {
        private float _maxPossiblePlayerProgress = 1f;

        private float _currentPlayerLevelProgress;

        public event Action OnFullLevelProgress;
        public event Action<float> OnProgressIncreased; //TODO: UI Progress bar should listen this

        private void Start() //TODO: get this from load file
        {
            _currentPlayerLevelProgress = 0;
            IncrementProgress(1.5f);
        }

        private void IncrementProgress(float amount) //TODO: Call this when player gets score
        {
            _currentPlayerLevelProgress += amount;
            OnProgressIncreased?.Invoke(_currentPlayerLevelProgress);
        }
    }
}
