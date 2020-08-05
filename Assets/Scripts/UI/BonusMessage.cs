using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class BonusMessage : MonoBehaviour
    {
        [SerializeField] private PopComboDetector.PopComboDetector _comboDetector;
        [SerializeField] private TextMeshProUGUI _bonusMessagePrefab;

        private void OnEnable()
        {
            _comboDetector.OnComboHitted += CreateBonusMessage;
        }
        
        private void CreateBonusMessage(int bonusModifier)
       {
           var message = Instantiate(_bonusMessagePrefab, transform);
           message.text = $"x{bonusModifier}!";
           
           Destroy(message.gameObject, 1f);
       }

        private void OnDisable()
        {
            _comboDetector.OnComboHitted -= CreateBonusMessage;
        }
    }
}
