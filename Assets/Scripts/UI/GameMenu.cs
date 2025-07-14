using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class GameMenu : UIScreen
    {
        [SerializeField]
        private Button _pauseButton;

        [SerializeField]
        private TextMeshPro _scoreValue;

        [SerializeField]
        private TextMeshPro _healthValue;

        private void OnEnable()
        {
            _pauseButton.onClick.AddListener(() => _gameState.Pause());

            _score.ChangeHealth += HandleChangeHealth;
            _score.ChangeScore += HandleChangeScore;

            HandleChangeHealth(_score.HealthValue);
            HandleChangeScore(_score.ScoreValue);
        }

        private void OnDisable()
        {
            _pauseButton.onClick.RemoveAllListeners();

            _score.ChangeHealth -= HandleChangeHealth;
            _score.ChangeScore -= HandleChangeScore;
        }

        private void HandleChangeHealth(int value)
        {
            _healthValue.text = value.ToString();
        }

        private void HandleChangeScore(int value)
        {
            _scoreValue.text = value.ToString();
        }
    }
}
