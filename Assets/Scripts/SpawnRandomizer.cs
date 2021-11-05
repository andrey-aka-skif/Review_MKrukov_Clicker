using UnityEngine;
using Random = System.Random;

public class SpawnRandomizer : MonoBehaviour
{
    [SerializeField, Range(1,10)] private int _maxPrizePoints = 10;
    [SerializeField, Range(1, 10)] private int _maxPlayerDamagePoints = 10;

    [SerializeField] private float _minSpeedValue = 0.1f;
    [SerializeField] private float _maxSpeedValue = 1;

    private readonly Random _rnd = new Random();

    public Color Color => new Color(
        (float)_rnd.NextDouble(), 
        (float)_rnd.NextDouble(), 
        (float)_rnd.NextDouble());

    public float Speed => (float)_rnd.NextDouble() * (_maxSpeedValue - _minSpeedValue) + _minSpeedValue;

    public int PrizePoints => _rnd.Next(1, _maxPrizePoints);

    public int PlayerDamagePoints => _rnd.Next(1, _maxPlayerDamagePoints);
}