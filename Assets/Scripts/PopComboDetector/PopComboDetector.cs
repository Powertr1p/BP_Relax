using UnityEngine;

namespace PopComboDetector
{
    public class PopComboDetector : MonoBehaviour
    {
        [SerializeField] private float _timeBetweenPopToEarnCombo = 0.3f;
        [SerializeField] private int _streakToEarnBonus = 3;

        private float _lastSavedTime = 999f;
        private int _comboCounter;

        public void CountComboPops()
        {
            var currentPopTime = Time.time;

            if (currentPopTime - _lastSavedTime < _timeBetweenPopToEarnCombo )
                _comboCounter++;
            else
                _comboCounter = 0;
            
            if (_comboCounter % _streakToEarnBonus == 0 && _comboCounter != 0)
                Debug.Log("STRIKE OF " + _comboCounter);
            
            _lastSavedTime = currentPopTime;
        }
    }
}
