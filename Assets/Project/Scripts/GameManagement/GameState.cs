﻿using System;
using UnityEngine;

namespace Assets.Project.Scripts.GameManagement
{
    /// <summary>
    /// Состояние игры
    /// </summary>
    public class GameState : IPausable
    {
        private bool _isPlaying = false;
        private bool _isDied = true;

        public bool IsPlaying => _isPlaying;

        public bool IsPaused => !_isPlaying && !_isDied;

        public event Action OnStarted;
        public event Action OnPaused;
        public event Action OnResumed;
        public event Action OnDied;
        public event Action OnStop;

        public void Start()
        {
            if (_isPlaying)
            {
                return;
            }

            if (_isDied)
            {
                _isPlaying = true;
                _isDied = false;
                OnStarted?.Invoke();
            }
            else
            {
                _isPlaying = true;
                OnResumed?.Invoke();
            }
        }

        public void Pause()
        {
            if (!_isPlaying)
            {
                return;
            }

            _isPlaying = false;
            OnPaused?.Invoke();
        }

        public void Restart()
        {
            Start();
        }

        public void Die()
        {
            if (_isDied)
            {
                return;
            }

            _isPlaying = false;
            _isDied = true;
            OnDied?.Invoke();
        }

        public void Stop()
        {
            _isPlaying = false;
            _isDied = true;
            OnStop?.Invoke();
        }

        public void AppQuit()
        {
#if UNITY_EDITOR
            Debug.LogWarning("Application.Quit");
#endif

            Application.Quit();
        }
    }
}
