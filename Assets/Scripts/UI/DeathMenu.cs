using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class DeathMenu : UIScreen
    {
        [SerializeField]
        private Button _playButton;

        [SerializeField]
        private Button _exitButton;

        [SerializeField]
        private TMP_Text _scoreValue;

        [SerializeField]
        private TMP_Text _bestScoreValue;

        private void OnEnable()
        {
            _playButton.onClick.AddListener(() => _gameState.Start());
            _exitButton.onClick.AddListener(() => _gameState.AppQuit());

            _scoreValue.text = _score.ScoreValue.ToString();
            _bestScoreValue.text = _score.BestScoreValue.ToString();
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
        }
    }
}
