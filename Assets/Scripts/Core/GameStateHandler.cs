using System.Collections;
using SlowMode;
using UI;
using UnityEngine;

namespace Core
{
    public class GameStateHandler : MonoBehaviour
    {
        [SerializeField] private SlowStateToggler _slowStateToggler;
        [SerializeField] private GameOverHandler _gameOverHandler;
        [SerializeField] private GamePause _gamePause;

        [SerializeField] private float _timeScaleInSlowState = 0.25f;
        [SerializeField] private float _normalTimeScale = 1f;

        public static GameState CurrentGameState { get; private set; }
        private GameState _previousState;

        private void OnEnable()
        {
            _slowStateToggler.SlowStateEnabled += OnSlowStateEnabled;
            _slowStateToggler.SlowStateDisabled += OnNormalState;
            _gameOverHandler.OnGameOver += OnGameOver;
            _gamePause.GamePaused += OnPaused;
            _gamePause.GameUnpaused += OnUnpaused;
        }

        private void Start()
        {
            OnNormalState();
        }

        private void Update()
        {
            if (CurrentGameState == GameState.SlowState)
                Time.fixedDeltaTime = Time.timeScale * 0.02f;

            if (CurrentGameState == GameState.Paused)
                Time.timeScale = 0f;
        }

        private void OnSlowStateEnabled()
        {
            StartCoroutine(WaitBeforeStartSlowState());
        }

        private IEnumerator WaitBeforeStartSlowState()
        {
            yield return new WaitForSecondsRealtime(0.5f);
            CurrentGameState = GameState.SlowState;
            Time.timeScale = _timeScaleInSlowState;
        }

        private void OnNormalState()
        {
            if (CurrentGameState == GameState.Paused) return;
            
            CurrentGameState = GameState.NormalState;
            Time.timeScale = 1f;
        }

        private void OnGameOver()
        {
            CurrentGameState = GameState.GameOver;
        }

        private void OnPaused()
        {
            _previousState = CurrentGameState;
            CurrentGameState = GameState.Paused;
        }

        private void OnUnpaused()
        {
            CurrentGameState = _previousState;
            Time.timeScale = _normalTimeScale;
        }
        
        private void OnDisable()
        {
            _slowStateToggler.SlowStateEnabled -= OnSlowStateEnabled;
            _slowStateToggler.SlowStateDisabled -= OnNormalState;
            _gameOverHandler.OnGameOver -= OnGameOver;
            _gamePause.GamePaused -= OnPaused;
            _gamePause.GameUnpaused -= OnUnpaused;
        }
    }

    public enum GameState
    {
        NormalState,
        SlowState,
        Paused,
        GameOver
    }
}


    
   