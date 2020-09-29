using System;
using System.Collections;
using PlayerProgress;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace UI
{
    public class PlayerProgressDisplay : MonoBehaviour
    {
        [SerializeField] private Slider _progressBarSlider;
        [SerializeField] private float _fillSpeed = 0.5f;
        [SerializeField] private TextMeshProUGUI _playerLevel;
        [SerializeField] private Score _score;
        [SerializeField] private PlayerProgressStorage _sessionData;

        private int _currentPlayerLevel;
        private float _targetProgress;

        public float GetScoreFormula() => _score.GetScore / 10000f;

        private void OnEnable()
        {
            StartCoroutine(WaitAndFillProgress());
        }

        private void Awake()
        {
            _currentPlayerLevel = _sessionData.Level;
            _progressBarSlider.value = _sessionData.Progress;
        }

        private void Start()
        {
            UpdateCurrentLevel();
        }
        
        private IEnumerator WaitAndFillProgress()
        {
            _sessionData.UpdateCurrentData(_currentPlayerLevel, _progressBarSlider.value + GetScoreFormula());
            yield return new WaitForSeconds(2.2f);
            IncrementProgress(GetScoreFormula());
        }

        private void UpdateCurrentLevel()
        {
            _playerLevel.text = $"Level: {_currentPlayerLevel.ToString()}";
        }

        private void Update()
        {
           MoveSlider();
           UpdateCurrentLevel();
        }

        private void MoveSlider()
        {
            if (_progressBarSlider.value < _targetProgress)
                _progressBarSlider.value += _fillSpeed * Time.deltaTime;

            if (_progressBarSlider.value >= _progressBarSlider.maxValue)
            {
                _targetProgress -= _progressBarSlider.value;
                _progressBarSlider.value = 0;
                _currentPlayerLevel++;
            }
        }

        private void IncrementProgress(float amount)
        {
            _targetProgress = _progressBarSlider.value + amount;
        }
    }
}