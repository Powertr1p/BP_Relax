using System;
using Interfaces;
using SlowMode;
using UnityEngine;

namespace Core
{
    public class GameModeHandler : MonoBehaviour, ILevelLoaderModeHandler
    {
        [SerializeField] private SlowStateToggler _slowStateToggler;
        public static GameMode CurrentGameMode { get; private set; }
        public static GameState CurrentGameState { get; private set; }

        private void OnEnable()
        {
            _slowStateToggler.SlowStateEnabled += OnSlowStateEnabled;
            _slowStateToggler.SlowStateDisabled += OnSlowStateDisabled;
        }

        public void OnLevelLoad(GameMode mode)
        {
            CurrentGameMode = mode;
        }

        private void OnSlowStateEnabled()
        {
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
    
    public enum GameMode
    {
        Relax, 
        Arcade
    }

    public enum GameState
    {
        NormalState,
        SlowState,
    }
}


    
   