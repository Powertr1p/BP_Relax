using System;
using TMPro;
using UnityEngine;

namespace PlayerProgress
{
    [RequireComponent(typeof(PlayerProgress))]
    public class PlayerLevel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _playerLevelText;

        private PlayerProgress _playerProgress;
        
        private int _currentPlayerLevel;

        private void Awake()
        {
            _playerProgress = GetComponent<PlayerProgress>();
        }

        private void OnEnable()
        {
            _playerProgress.OnFullLevelProgress += IncreasePlayerLevel;
            _playerProgress.OnFullLevelProgress += UpdatePlayerLevelText;
        }

        private void Start()
        {
            _currentPlayerLevel = 1;
            UpdatePlayerLevelText();
        }
    
        private void IncreasePlayerLevel()
        {
            _currentPlayerLevel++;
        }

        private void UpdatePlayerLevelText()
        {
            _playerLevelText.text = $"Level {_currentPlayerLevel.ToString()}";
        }

        private void OnDisable()
        {
            _playerProgress.OnFullLevelProgress -= IncreasePlayerLevel;
            _playerProgress.OnFullLevelProgress += UpdatePlayerLevelText;
        }
    }
}
