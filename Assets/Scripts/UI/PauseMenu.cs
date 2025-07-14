using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class PauseMenu : UIScreen
    {
        [SerializeField]
        private Button _exitButton;

        [SerializeField]
        private Button _restartButton;

        [SerializeField]
        private Button _resumeButton;

        [SerializeField]
        private TextMeshPro _scoreValue;

        [SerializeField]
        private TextMeshPro _bestScoreValue;

        protected void OnEnable()
        {
            _exitButton.onClick.AddListener(() => _gameState.Stop());
            _restartButton.onClick.AddListener(() => _gameState.Play());
            _resumeButton.onClick.AddListener(() => _gameState.Play());

            _scoreValue.text = _score.ScoreValue.ToString();
            _bestScoreValue.text = _score.BestScoreValue.ToString();
        }

        protected void OnDisable()
        {
            _exitButton.onClick.RemoveAllListeners();
            _restartButton.onClick.RemoveAllListeners();
            _resumeButton.onClick.RemoveAllListeners();
        }
    }
}
