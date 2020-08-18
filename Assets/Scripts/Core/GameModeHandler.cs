using System;
using System.Collections;
using Interfaces;
using SlowMode;
using UnityEngine;

namespace Core
{
    public class GameModeHandler : MonoBehaviour
    {
        [SerializeField] private SlowStateToggler _slowStateToggler;

        public static GameState CurrentGameState { get; private set; }

        private void OnEnable()
        {
            _slowStateToggler.SlowStateEnabled += OnSlowStateEnabled;
            _slowStateToggler.SlowStateDisabled += OnSlowStateDisabled;
        }

        private void Update()
        {
            if (CurrentGameState == GameState.SlowState)
                Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }

        private void OnSlowStateEnabled()
        {
            StartCoroutine(WaitBeforeStartSlowState());
        }

        private IEnumerator WaitBeforeStartSlowState()
        {
            yield return new WaitForSecondsRealtime(0.5f);
            CurrentGameState = GameState.SlowState;
            Time.timeScale = 0.25f;
        }

        private void OnSlowStateDisabled()
        {
            CurrentGameState = GameState.NormalState;
            Time.timeScale = 1f;
        }

        private void OnDisable()
        {
            _slowStateToggler.SlowStateEnabled -= OnSlowStateEnabled;
            _slowStateToggler.SlowStateDisabled -= OnSlowStateDisabled;
        }
    }

    public enum GameState
    {
        NormalState,
        SlowState,
    }
}


    
   