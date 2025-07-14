using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class StartMenu : UIScreen
    {
        [SerializeField]
        private Button _playButton;

        [SerializeField]
        private Button _exitButton;

        [SerializeField]
        private TextMeshPro _scoreValue;

        [SerializeField]
        private TextMeshPro _bestScoreValue;

        protected void OnEnable()
        {
            _playButton.onClick.AddListener(() => _gameState.Play());
            _exitButton.onClick.AddListener(() => _gameState.AppQuit());

            _scoreValue.text = _score.ScoreValue.ToString();
            _bestScoreValue.text = _score.BestScoreValue.ToString();
        }

        protected void OnDisable()
        {
            _playButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
        }
    }
}
