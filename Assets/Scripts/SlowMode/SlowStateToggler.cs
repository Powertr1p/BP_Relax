using System;
using System.Collections;
using UnityEngine;

namespace SlowMode
{
    public class SlowStateToggler : MonoBehaviour
    {
        [SerializeField] private float _timeInSlowState = 7f;
        public event Action SlowStateEnabled;
        public event Action SlowStateDisabled;

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
    }
}
