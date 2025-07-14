﻿using UnityEngine;

namespace Assets.Scripts.GameManagement
{
    /// <summary>
    /// Контроллер игрового времени через Time.timeScale
    /// </summary>
    public class GameTimeController : MonoBehaviour
    {
        private GameState _gameState;

        public void Init(GameState gameState)
        {
            _gameState = gameState;

            _gameState.OnPlayed += HandlePlay;
            _gameState.OnPaused += HandlePause;
            _gameState.OnResumed += HandlePlay;
            _gameState.OnDied += HandlePause;
        }

        private void OnDestroy()
        {
            if (_gameState == null)
            {
                return;
            }

            _gameState.OnPlayed -= HandlePlay;
            _gameState.OnPaused -= HandlePause;
            _gameState.OnResumed -= HandlePlay;
            _gameState.OnDied -= HandlePause;
        }

        private void HandlePlay() => Time.timeScale = 1.0f;

        private void HandlePause() => Time.timeScale = 0.0f;
    }

}
