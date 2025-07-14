using Assets.Scripts.GameManagement;
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
        private TMP_Text _scoreValue;

        [SerializeField]
        private TMP_Text _healthValue;

        private int _maxHealth;

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

        public override void Init(GameState gameState, GameScore score)
        {
            base.Init(gameState, score);
            _maxHealth = score.HealthValue;

            SetHealthValueColor(score.HealthValue);
        }

        private void HandleChangeHealth(int value)
        {
            _healthValue.text = value.ToString();

            SetHealthValueColor(value);
        }

        private void HandleChangeScore(int value)
        {
            _scoreValue.text = value.ToString();
        }

        private void SetHealthValueColor(int healthValue)
        {
            var ratio = (float)healthValue / _maxHealth;

            var color = Color.green;

            if (ratio > .5f && ratio <= .75f)
                color = Color.grey;
            else if (ratio > .25f && ratio <= .5f)
                color = Color.yellow;
            else if (ratio <= .25f)
                color = Color.red;

            _healthValue.color = color;
        }
    }
}
