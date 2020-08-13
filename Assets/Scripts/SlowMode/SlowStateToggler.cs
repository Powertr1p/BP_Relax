using System;
using System.Collections;
using UnityEngine;

namespace SlowMode
{
    public class SlowStateToggler : MonoBehaviour
    {
        public event Action SlowStateEnabled;
        public event Action SlowStateDisabled;

        public void StartBehavior()
        {
            SlowStateEnabled?.Invoke();
            StartCoroutine(StartCountdownToDisableBehavior());
        }

        private IEnumerator StartCountdownToDisableBehavior()
        {
            yield return new WaitForSecondsRealtime(5f);
            EndBehavior();
        }

        private void EndBehavior()
        {
            SlowStateDisabled?.Invoke();
        }
    }
}
