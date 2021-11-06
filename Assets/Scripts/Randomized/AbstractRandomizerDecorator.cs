using UnityEngine;

public abstract class AbstractRandomizerDecorator : IRandomizer
{
    protected Randomizer _randomizer;

    public AbstractRandomizerDecorator(Randomizer randomizer)
    {
        _randomizer = randomizer;
    }

    public virtual Color Color => _randomizer.Color;
    public virtual int Damage => _randomizer.Damage;
    public virtual int Prize => _randomizer.Prize;
    public virtual float Speed => _randomizer.Speed;

    public virtual void Reset()
    {
        _randomizer?.Reset();
    }
}