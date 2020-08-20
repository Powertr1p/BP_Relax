using System;
using System.Collections;
using Interfaces;
using SlowMode;
using UnityEngine;

namespace Core
{
    public class GameStateHandler : MonoBehaviour
    {
        [SerializeField] private SlowStateToggler _slowStateToggler;
        [SerializeField] private GameOverHandler _gameOverHandler;
        public static GameState CurrentGameState { get; private set; }

        private void OnEnable()
        {
            _slowStateToggler.SlowStateEnabled += OnSlowStateEnabled;
            _slowStateToggler.SlowStateDisabled += OnNormalState;
            _gameOverHandler.OnGameOver += OnGameOver;
        }

        private void Start()
        {
            OnNormalState();
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

        private void OnNormalState()
        {
            CurrentGameState = GameState.NormalState;
            Time.timeScale = 1f;
        }

        private void OnGameOver()
        {
            CurrentGameState = GameState.GameOver;
            Time.timeScale = 0f;
        }

        private void OnDisable()
        {
            _slowStateToggler.SlowStateEnabled -= OnSlowStateEnabled;
            _slowStateToggler.SlowStateDisabled -= OnNormalState;
            _gameOverHandler.OnGameOver -= OnGameOver;
        }
    }

    public enum GameState
    {
        NormalState,
        SlowState,
        GameOver
    }
}


    
   