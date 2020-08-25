using System;
using System.Collections;
using Core;
using PlayerInput;
using UnityEngine;

namespace SlowMode
{
    public class SlowStateToggler : MonoBehaviour
    {
        [SerializeField] private float _timeInSlowState = 7f;
        [SerializeField] private TapDetector _tapDetector;
        public event Action SlowStateEnabled;
        public event Action SlowStateDisabled;

        private void OnEnable()
        {
            _tapDetector.OnLongTapSuccess += StartBehavior;
        }

        public void StartBehavior()
        {
            SlowStateEnabled?.Invoke();
            StartCoroutine(StartCountdownToDisableBehavior());
        }

        private IEnumerator StartCountdownToDisableBehavior()
        {
            yield return new WaitForSecondsRealtime(_timeInSlowState);
            EndBehavior();
        }

        private void EndBehavior()
        {
            SlowStateDisabled?.Invoke();
        }

        private void OnDisable()
        {
            _tapDetector.OnLongTapSuccess -= StartBehavior;
        }
    }
}
