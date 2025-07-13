using System;

/// <summary>
/// Рандомайзер, добавляющий увеличение скорости
/// </summary>
/// <remarks>
/// Каждый следующий шар будет иметь большую скорость
/// </remarks>
public class AcceleratingRandomizerDecorator : AbstractRandomizerDecorator
{
    private float _additionalSpeed;
    private readonly float _maxSpeed = 100f;

    /// <summary>
    /// Шаг увеличения скорости
    /// </summary>
    public float Increase { get; set; }

    public AcceleratingRandomizerDecorator(Randomizer randomizer) : base(randomizer) { }

    public override float Speed => Math.Min(base.Speed + _additionalSpeed, _maxSpeed);

    public override void Reset()
    {
        _additionalSpeed = 0;
    }
}
