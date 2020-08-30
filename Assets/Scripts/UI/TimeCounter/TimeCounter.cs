using System;
using System.Collections;
using SlowMode;
using TMPro;
using UnityEngine;

namespace UI.TimeCounter
{
   public class TimeCounter : MonoBehaviour
   { 
      [SerializeField] private TextMeshProUGUI _timeText;
      [SerializeField] private int _levelTime = 60;
      [SerializeField] private Color _warningTimeColor;
      [SerializeField] private SlowStateToggler _toggler;

      public event Action OnTimeIsUp;

      private Color _defaultColor;

      private void OnEnable()
      {
         _toggler.SlowStateEnabled += HideTimerInSlowState;
         _toggler.SlowStateDisabled += ShowTimer;
      }

      private void Start()
      {
         _defaultColor = _timeText.color;
         
         StartCoroutine(StartCountdown());
      }
      
      private IEnumerator StartCountdown()
      {
         while (_levelTime >= 0)
         {
            DisplayTime();
            yield return new WaitForSeconds(1f);
            _levelTime--;
         }
         
         OnTimeIsUp?.Invoke();
      }

      private void DisplayTime()
      {
         _timeText.text = _levelTime.ToString();

         if (_levelTime == 5)
            _timeText.color = _warningTimeColor;
      }

      private void HideTimerInSlowState()
      {
         _timeText.color = Color.clear;
      }

      private void ShowTimer()
      {
         _timeText.color = _defaultColor;
      }

      private void OnDisable()
      {
         _toggler.SlowStateEnabled -= HideTimerInSlowState;
         _toggler.SlowStateDisabled -= ShowTimer;
      }
   }
}
