using System;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerProgress
{
    public class PlayerProgress : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private float _currentPlayerLevelProgress;

        public event Action OnFullLevelProgress;

        public bool INC;
        
        private void Start()
        {
            _currentPlayerLevelProgress = 0;
        }

        private void Update()
        {
            if (INC)
                IncreaseProgress();
            INC = false;
        }

        private void IncreaseProgress()
        {
            _currentPlayerLevelProgress += 0.1f;
            _slider.value = _currentPlayerLevelProgress;

            if (_currentPlayerLevelProgress >= _slider.maxValue)
            {
                OnFullLevelProgress?.Invoke();
                _currentPlayerLevelProgress = 0f;
                _slider.value = 0f;
            }
                
        }
    }
}
