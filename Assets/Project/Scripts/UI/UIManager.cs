using Assets.Project.Scripts.GameManagement;
using UnityEngine;

namespace Assets.Project.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private StartMenu _startMenu;

        [SerializeField]
        private GameMenu _gameMenu;

        [SerializeField]
        private PauseMenu _pauseMenu;

        [SerializeField]
        private DeathMenu _deathMenu;

        private GameState _gameState;

        private void OnDestroy()
        {
            UnsubscribeFromStateEvents();
        }

        public void Init(GameState gameState, GameScore score)
        {
            _gameState = gameState;

            _startMenu.Init(gameState, score);
            _gameMenu.Init(gameState, score);
            _pauseMenu.Init(gameState, score);
            _deathMenu.Init(gameState, score);

            SubscribeToStateEvents();
        }

        public void ShowStartMenu()
        {
            _startMenu.Show();
            _gameMenu.Hide();
            _pauseMenu.Hide();
            _deathMenu.Hide();
        }

        public void ShowGameMenu()
        {
            _startMenu.Hide();
            _gameMenu.Show();
            _pauseMenu.Hide();
            _deathMenu.Hide();
        }

        public void ShowPauseMenu()
        {
            _startMenu.Hide();
            _gameMenu.Hide();
            _pauseMenu.Show();
            _deathMenu.Hide();
        }

        public void ShowDeathMenu()
        {
            _startMenu.Hide();
            _gameMenu.Hide();
            _pauseMenu.Hide();
            _deathMenu.Show();
        }

        private void SubscribeToStateEvents()
        {
            if (_gameState == null)
                return;

            _gameState.OnStarted += ShowGameMenu;
            _gameState.OnPaused += ShowPauseMenu;
            _gameState.OnResumed += ShowGameMenu;
            _gameState.OnDied += ShowDeathMenu;
            _gameState.OnStop += ShowStartMenu;
        }

        private void UnsubscribeFromStateEvents()
        {
            if (_gameState == null)
                return;

            _gameState.OnStarted -= ShowGameMenu;
            _gameState.OnPaused -= ShowPauseMenu;
            _gameState.OnResumed -= ShowGameMenu;
            _gameState.OnDied -= ShowDeathMenu;
            _gameState.OnStop -= ShowStartMenu;
        }
    }
}
