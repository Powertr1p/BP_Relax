using System;
using UnityEngine;
using PlayerProgress;
using UnityEngine.UI;

namespace UI
{
    public class PlayerProgressBarDisplay : MonoBehaviour
    {
        [SerializeField] private Slider _progressBarSlider;
        [SerializeField] private PlayerLevelProgress _playerLevelProgress;

        private void OnEnable()
        {
            _playerLevelProgress.OnProgressIncreased += IncreaseBarValue;
        }

        private void IncreaseBarValue(float amount)
        {
            float amountToAdd = amount;
            while (amountToAdd > 0.01f)
            {
                amountToAdd -= -0.01f;
                _progressBarSlider.value += 0.01f;

                if (_progressBarSlider.value >= 1f)
                    _progressBarSlider.value = 0f;
            }
        }
    }
}