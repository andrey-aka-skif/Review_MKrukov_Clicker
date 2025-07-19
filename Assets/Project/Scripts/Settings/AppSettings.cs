using UnityEngine;

/// <summary>
/// Объект с настройками приложения
/// </summary>
[CreateAssetMenu(fileName = "AppSettings", menuName = "AppSettings", order = 1)]
public class AppSettings : ScriptableObject
{
    [SerializeField]
    private Ball _prefab;


    [SerializeField]
    private float _minCreationTime = 1;

    [SerializeField]
    private float _maxCreationTime = 5;


    [SerializeField]
    private float _creationTimeDecrease = .01f;


    [SerializeField]
    private int _poolCapacity = 10;


    [SerializeField, Range(1, 10)]
    private int _maxPrize = 10;

    [SerializeField, Range(1, 10)]
    private int _maxDamage = 10;


    [SerializeField]
    private float _minSpeed = 0.1f;

    [SerializeField]
    private float _maxSpeed = 1;


    [SerializeField]
    private float _speedIncrease = .1f;


    [SerializeField]
    private float _acceleration = .01f;


    [SerializeField]
    private int _startHealth = 10;


    [SerializeField]
    private string _bestScoreKey = "BestScore";


    public Ball Prefab => _prefab;
    public float MinCreationTime => _minCreationTime;
    public float MaxCreationTime => _maxCreationTime;
    public int PoolCapacity => _poolCapacity;
    public int MaxPrize => _maxPrize;
    public int MaxDamage => _maxDamage;
    public float MinSpeed => _minSpeed;
    public float MaxSpeed => _maxSpeed;
    public float Acceleration => _acceleration;
    public int StartHealth => _startHealth;
    public string BestScoreKey => _bestScoreKey;
    public float SpeedIncrease => _speedIncrease;
    public float CreationTimeDecrease => _creationTimeDecrease;
}
