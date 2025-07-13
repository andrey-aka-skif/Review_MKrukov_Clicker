using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Текущий счет
/// </summary>
public class Score : MonoBehaviour
{
    [SerializeField]
    private UnityEvent Dead;

    [SerializeField]
    private ChangeHealthEvent ChangeHealth;

    [SerializeField]
    private ChangeScoreEvent ChangeScore;

    [SerializeField]
    private ChangeBestScoreEvent ChangeBestScore;

    private string _bestScoreKey = "BestScore";

    private int _score;
    private int _startHealth;
    private int _health;

    /// <summary>
    /// Лучший результат
    /// </summary>
    public int BestScore
    {
        get => PlayerPrefs.GetInt(_bestScoreKey);
        private set => PlayerPrefs.SetInt(_bestScoreKey, value);
    }

    /// <summary>
    /// Инициализировать
    /// </summary>
    /// <param name="startHealth">Начальное здоровье</param>
    /// <param name="bestScoreKey">Ключ в PlayerPrefs для лучшего результата</param>
    public void Init(int startHealth, string bestScoreKey)
    {
        _startHealth = startHealth;
        _health = startHealth;
        _bestScoreKey = bestScoreKey;
        Restart();
    }

    /// <summary>
    /// Перезапустить счет
    /// </summary>
    public void Restart()
    {
        _score = 0;
        _health = _startHealth;

        Dead ??= new UnityEvent();
        ChangeHealth ??= new ChangeHealthEvent();
        ChangeScore ??= new ChangeScoreEvent();

        ChangeHealth?.Invoke(_health);
        ChangeScore?.Invoke(_score);
        ChangeBestScore?.Invoke(BestScore);
    }

    /// <summary>
    /// Добавить очки
    /// </summary>
    /// <param name="score">Число очков</param>
    public void OnScoreAdd(int score)
    {
        _score += score;

        if (_score > BestScore)
        {
            BestScore = _score;
            ChangeBestScore?.Invoke(BestScore);
        }

        ChangeScore?.Invoke(_score);
    }

    /// <summary>
    /// Добавить урон
    /// </summary>
    /// <param name="damage"></param>
    public void OnDamageAdd(int damage)
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
