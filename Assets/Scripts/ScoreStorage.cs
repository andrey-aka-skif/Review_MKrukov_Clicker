using UnityEngine;

[CreateAssetMenu(fileName = "ScoreStorage", menuName = "ScoreStorage", order = 1)]
public class ScoreStorage : ScriptableObject
{
    [SerializeField] private int _bestScore;
    [SerializeField] private int _defaultHealth = 25;

    public int BestScore
    {
        get => _bestScore;
        set => _bestScore = value;
    }

    public int DefaultHealth => _defaultHealth;
}