using System;
using System.Collections;
using Core;
using PlayerInput;
using UnityEngine;
using UnityEngine.UI;

namespace SlowMode
{
    public class SlowStateToggler : MonoBehaviour
    {
        [SerializeField] private float _timeInSlowState = 7f;
        [SerializeField] private TapDetector _tapDetector;
        public event Action SlowStateEnabled;
        public event Action SlowStateDisabled;

        public bool CanActivate { get; private set; }

        private void OnEnable()
        {
            _tapDetector.OnLongTapSuccess += StartBehavior;
        }

        private void Start()
        {
            CanActivate = true;
        }

        private void StartBehavior()
        {
            if (!CanActivate) return;

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
            CanActivate = false;
        }

        private void OnDisable()
        {
            _tapDetector.OnLongTapSuccess -= StartBehavior;
        }
    }
}
