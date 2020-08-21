using System;
using UnityEngine;

namespace UI
{
    public class TimeIsUpMessageHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _timeIsUpText;
        [SerializeField] private TimeCounter.TimeCounter _counter;
        private Animator _textAnimator;
        
        private static readonly int ShowText = Animator.StringToHash("ShowText");

        private void Awake()
        {
            _textAnimator = _timeIsUpText.GetComponent<Animator>();
        }

        private void OnEnable()
        {
            _counter.OnTimeIsUp += DisplayText;
        }

        private void DisplayText()
        {
            _textAnimator.SetTrigger(ShowText);
        }

        private void OnDisable()
        {
            _counter.OnTimeIsUp -= DisplayText;
        }
    }
}
