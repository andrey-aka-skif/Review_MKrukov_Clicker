using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project.Scripts.UI
{
    public class StartMenu : UIScreen
    {
        [SerializeField]
        private Button _playButton;

        [SerializeField]
        private Button _exitButton;

        [SerializeField]
        private TMP_Text _bestScoreValue;

        protected void OnEnable()
        {
            _playButton.onClick.AddListener(() => _gameState.Start());
            _exitButton.onClick.AddListener(() => _gameState.AppQuit());

            _bestScoreValue.text = _score.BestScoreValue.ToString();
        }

        protected void OnDisable()
        {
            _playButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
        }
    }
}
