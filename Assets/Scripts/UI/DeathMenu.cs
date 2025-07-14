using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class DeathMenu : UIScreen
    {
        [SerializeField]
        private Button _stopButton;

        [SerializeField]
        private Button _playButton;

        [SerializeField]
        private TextMeshPro _scoreValue;

        [SerializeField]
        private TextMeshPro _bestScoreValue;

        private void OnEnable()
        {
            _stopButton.onClick.AddListener(() => _gameState.Stop());
            _playButton.onClick.AddListener(() => _gameState.Play());

            _scoreValue.text = _score.ScoreValue.ToString();
            _bestScoreValue.text = _score.BestScoreValue.ToString();
        }

        private void OnDisable()
        {
            _stopButton.onClick.RemoveAllListeners();
            _playButton.onClick.RemoveAllListeners();
        }
    }
}
