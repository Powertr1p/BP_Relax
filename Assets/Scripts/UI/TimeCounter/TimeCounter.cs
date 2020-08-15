using System;
using System.Collections;
using Core;
using TMPro;
using UnityEngine;

namespace UI.TimeCounter
{
   public class TimeCounter : MonoBehaviour
   { 
      [SerializeField] private TextMeshProUGUI _timeText;
      [SerializeField] private float _relaxModeTimeCount = 99f;
      [SerializeField] private float _arcadeModeTimeCount = 25f;
      private float _levelTime;

      public event Action OnTimeIsUp; 
      
      private void Start()
      {
         _levelTime = GameModeHandler.CurrentGameMode == GameMode.Relax ? _relaxModeTimeCount : _arcadeModeTimeCount;
         
         StartCoroutine(StartCountdown());
      }
      
      private IEnumerator StartCountdown()
      {
         while (_levelTime >= 0)
         {
            DisplayTime();
            yield return new WaitForSecondsRealtime(1f);
            _levelTime--;
         }
         
         OnTimeIsUp?.Invoke();
      }

      private void DisplayTime()
      {
         _timeText.text = _levelTime.ToString();
      }
   }
}
