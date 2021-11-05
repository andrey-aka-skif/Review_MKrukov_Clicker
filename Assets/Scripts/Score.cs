using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private UnityEvent Dead;
    [SerializeField] private ChangeHealthEvent ChangeHealth;
    [SerializeField] private ChangeScoreEvent ChangeScore;
    [SerializeField] private ChangeBestScoreEvent ChangeBestScore;

    private ScoreStorage _storage;

    private int _score;
    private int _health;

    public int MaxScore => _storage.BestScore;

    public void Init(ScoreStorage storage)
    {
        _storage = storage;
        Restart();
    }

    public void Restart()
    {
        _score = 0;
        _health = _storage.DefaultHealth;

        Dead ??= new UnityEvent();
        ChangeHealth ??= new ChangeHealthEvent();
        ChangeScore ??= new ChangeScoreEvent();

        ChangeHealth?.Invoke(_health);
        ChangeScore?.Invoke(_score);
        ChangeBestScore?.Invoke(_storage.BestScore);
    }

    public void OnScoreAdd(int score)
    {
        _score += score;

        if(_score > MaxScore)
        {
            _storage.BestScore = _score;
            ChangeBestScore?.Invoke(_storage.BestScore);
        }

        ChangeScore?.Invoke(_score);
    }

    public void OnDamageAdd(int damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            Dead?.Invoke();
        }

        ChangeHealth?.Invoke(_health);
    }
}