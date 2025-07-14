using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project.Scripts.UI
{
    public class PauseMenu : UIScreen
    {
        [SerializeField]
        private Button _resumeButton;

        [SerializeField]
        private Button _restartButton;

        [SerializeField]
        private Button _exitButton;

        [SerializeField]
        private TMP_Text _scoreValue;

        [SerializeField]
        private TMP_Text _bestScoreValue;

        protected void OnEnable()
        {
            _resumeButton.onClick.AddListener(() => _gameState.Start());
            _restartButton.onClick.AddListener(() => _gameState.Restart());
            _exitButton.onClick.AddListener(() => _gameState.AppQuit());

            _scoreValue.text = _score.ScoreValue.ToString();
            _bestScoreValue.text = _score.BestScoreValue.ToString();
        }

        protected void OnDisable()
        {
            _resumeButton.onClick.RemoveAllListeners();
            _restartButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
        }
    }
}
