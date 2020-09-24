using System;
using TMPro;
using UnityEngine;

namespace PlayerProgress
{
    [RequireComponent(typeof(PlayerLevelProgress))]
    public class PlayerLevel : MonoBehaviour //TODO: Delete MonoBehaviour
    {
        private PlayerLevelProgress _playerLevelProgress;
        
        private int _currentPlayerLevel;

        private void Awake()
        {
            _playerLevelProgress = GetComponent<PlayerLevelProgress>();
        }

        private void OnEnable()
        {
            _playerLevelProgress.OnFullLevelProgress += IncreasePlayerLevelLevel;
        }

        private void Start() //TODO: get this from load file
        {
            _currentPlayerLevel = 1;
        }
    
        private void IncreasePlayerLevelLevel()
        {
            _currentPlayerLevel++;
        }

        private void OnDisable()
        {
            _playerLevelProgress.OnFullLevelProgress -= IncreasePlayerLevelLevel;
        }
    }
}
