using System;

namespace Assets.Scripts.GameManagement
{
    public class GameScore
    {
        public event Action Dead;

        public event Action<int> ChangeHealth;

        public event Action<int> ChangeScore;

        public event Action<int> ChangeBestScore;

        private int _score = 0;
        private int _health = 1;

        private readonly BestScoreSaver _bestScoreSaver;

        public GameScore(BestScoreSaver bestScoreSaver)
        {
            _bestScoreSaver = bestScoreSaver;
        }

        public int HealthValue => _health;

        public int ScoreValue => _score;

        public int BestScoreValue
        {
            get => _bestScoreSaver.GetValue();
            private set => _bestScoreSaver.SaveValue(value);
        }

        public void Restart(int score, int health)
        {
            _score = score;
            _health = health;

            ChangeHealth?.Invoke(_health);
            ChangeScore?.Invoke(_score);
            ChangeBestScore?.Invoke(BestScoreValue);
        }

        public void AddScore(int score)
        {
            _score += score;

            if (_score > BestScoreValue)
            {
                BestScoreValue = _score;
                ChangeBestScore?.Invoke(BestScoreValue);
            }

            ChangeScore?.Invoke(_score);
        }

        public void AddDamage(int damage)
        {
            if (_health <= 0)
            {
                return;
            }

            _health -= damage;

            if (_health <= 0)
            {
                _health = 0;
                ChangeHealth?.Invoke(_health);
                Dead?.Invoke();
                return;
            }

            ChangeHealth?.Invoke(_health);
        }
    }
}
