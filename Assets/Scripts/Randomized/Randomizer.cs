using UnityEngine;
using Random = System.Random;

public class Randomizer : IRandomizer
{
    private readonly int _maxPrize;
    private readonly int _maxDamage;

    private readonly float _minSpeed;
    private readonly float _maxSpeed;

    private readonly Random _rnd = new Random();

    public Randomizer(int maxPrize, int maxDamage, float minSpeed, float maxSpeed)
    {
        _maxPrize = maxPrize;
        _maxDamage = maxDamage;
        _minSpeed = minSpeed;
        _maxSpeed = maxSpeed;
    }

    public virtual Color Color => new Color(
        (float)_rnd.NextDouble(),
        (float)_rnd.NextDouble(),
        (float)_rnd.NextDouble());

    public virtual float Speed => (float)_rnd.NextDouble() * (_maxSpeed - _minSpeed) + _minSpeed;

    public virtual int Prize => _rnd.Next(1, _maxPrize);

    public virtual int Damage => _rnd.Next(1, _maxDamage);

    public virtual void Reset() { }
}