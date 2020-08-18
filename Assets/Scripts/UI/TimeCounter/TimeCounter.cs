using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace UI.TimeCounter
{
   public class TimeCounter : MonoBehaviour
   { 
      [SerializeField] private TextMeshProUGUI _timeText;
      [SerializeField] private float _levelTime = 60f;

      public event Action OnTimeIsUp; 
      
      private void Start()
      {
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
      }
   }
}
