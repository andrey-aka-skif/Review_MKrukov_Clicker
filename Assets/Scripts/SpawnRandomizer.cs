using UnityEngine;
using Random = System.Random;

public class SpawnRandomizer
{
    private readonly int _maxPrize = 10;
    private readonly int _maxDamage = 10;

    private readonly float _minSpeed = 0.1f;
    private readonly float _maxSpeed = 1;

    private readonly Random _rnd = new Random();

    public SpawnRandomizer(int maxPrize = 10, int maxDamage = 10, float minSpeed = 0.1f, float maxSpeed = 1)
    {
        _maxPrize = maxPrize;
        _maxDamage = maxDamage;
        _minSpeed = minSpeed;
        _maxSpeed = maxSpeed;
    }

    public Color Color => new Color(
        (float)_rnd.NextDouble(),
        (float)_rnd.NextDouble(),
        (float)_rnd.NextDouble());

    public float Speed => (float)_rnd.NextDouble() * (_maxSpeed - _minSpeed) + _minSpeed;

    public int Prize => _rnd.Next(1, _maxPrize);

    public int Damage => _rnd.Next(1, _maxDamage);
}