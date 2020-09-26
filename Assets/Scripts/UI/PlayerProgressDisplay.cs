using System;
using System.Collections;
using UnityEngine;
using PlayerProgress;
using TMPro;
using UnityEngine.UI;

namespace UI
{
    public class PlayerProgressDisplay : MonoBehaviour
    {
        [SerializeField] private Slider _progressBarSlider;
        [SerializeField] private PlayerLevelProgress _playerLevelProgress;
        [SerializeField] private float _fillSpeed = 0.5f;
        [SerializeField] private TextMeshProUGUI _playerLevel;
        [SerializeField] private Score _score;

        private float _currentPlayerLevel;
        private float _targetProgress;

        private void OnEnable()
        {
            _playerLevelProgress.OnProgressIncreased += IncrementProgress;
            StartCoroutine(WaitAndFillProgress());
        }

        private IEnumerator WaitAndFillProgress()
        {
            yield return new WaitForSeconds(3f);
            IncrementProgress(_score.GetScore / 10000f);
        }

        private void Start()
        {
            _currentPlayerLevel = 1;
            UpdateCurrentLevel();
        }

        private void UpdateCurrentLevel()
        {
            _playerLevel.text = $"Level: {_currentPlayerLevel.ToString()}";
        }

        private void Update()
        {
            if (_progressBarSlider.value < _targetProgress)
                _progressBarSlider.value += _fillSpeed * Time.deltaTime;

            if (_progressBarSlider.value >= _progressBarSlider.maxValue)
            {
                _targetProgress -= _progressBarSlider.value;
                _progressBarSlider.value = 0;
                _currentPlayerLevel++;
                UpdateCurrentLevel();
            }
        }

        private void IncrementProgress(float amount)
        {
            _targetProgress =  amount;
        }
    }
}