using System;
using System.Collections.Generic;
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
        private readonly List<IPausable> _pauseables;

        public GameState(List<IPausable> pauseables)
        {
            _pauseables = pauseables;
        }

        public bool IsPlaying => _isPlaying;

        public bool IsPaused => !_isPlaying && !_isDied;

        public event Action OnStarted;
        public event Action OnPaused;
        public event Action OnResumed;
        public event Action OnDied;
        public event Action OnStop;

        public void Play()
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

            PlayAll();
        }

        public void Pause()
        {
            if (!_isPlaying)
            {
                return;
            }

            _isPlaying = false;
            PauseAll();
            OnPaused?.Invoke();
        }

        public void Restart()
        {
            Play();
        }

        public void Die()
        {
            if (_isDied)
            {
                return;
            }

            StopAll();
            _isPlaying = false;
            _isDied = true;
            OnDied?.Invoke();
        }

        public void Stop()
        {
            _isPlaying = false;
            _isDied = true;
            StopAll();
            OnStop?.Invoke();
        }

        public void AppQuit()
        {
#if UNITY_EDITOR
            Debug.LogWarning("Application.Quit");
#endif

            Application.Quit();
        }

        private void PlayAll()
        {
            foreach (var item in _pauseables)
            {
                item.Play();
            }
        }

        private void StopAll()
        {
            foreach (var item in _pauseables)
            {
                item.Stop();
            }
        }

        private void PauseAll()
        {
            foreach (var item in _pauseables)
            {
                item.Pause();
            }
        }
    }
}
