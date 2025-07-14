using Assets.Scripts.GameManagement;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public abstract class UIScreen : MonoBehaviour
    {
        protected GameState _gameState;
        protected GameScore _score;

        public virtual void Init(GameState gameState, GameScore score)
        {
            _gameState = gameState;
            _score = score;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide() => gameObject.SetActive(false);

        protected virtual void HandleChangeHealth() { }

        protected virtual void HandleChangeScore() { }
    }
}
