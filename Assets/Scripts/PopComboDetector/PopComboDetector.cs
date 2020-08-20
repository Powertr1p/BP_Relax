using System;
using PlayerInput;
using UnityEngine;

namespace PopComboDetector
{
    public class PopComboDetector : MonoBehaviour
    {
        [SerializeField] private OnBubbleHitHandler _handler;
        
        [SerializeField] private float _timeBetweenPopToEarnCombo = 0.1f;
        [SerializeField] private int _streakToEarnBonus = 3;
       
        public event Action<int> OnComboHitted;
       
        public int ScoreMultiplier => _comboCounter;
        
        private float _lastSavedTime = 999f;
        private int _comboCounter;

        private void OnEnable()
        {
            _handler.OnBubblePoped += CountComboPops;
        }

        private void CountComboPops(int scoreFromBubble)
        {
            if (scoreFromBubble == 0) return;
            
            var currentPopTime = Time.time;
            if (currentPopTime - _lastSavedTime < _timeBetweenPopToEarnCombo)
                _comboCounter++;
            else
                _comboCounter = 0;
            
            if (_comboCounter % _streakToEarnBonus == 0 && _comboCounter != 0)
               OnComboHitted?.Invoke(_comboCounter);
            
            _lastSavedTime = currentPopTime;
        }

        private void OnDisable()
        {
            _handler.OnBubblePoped -= CountComboPops;
        }
    }
}
