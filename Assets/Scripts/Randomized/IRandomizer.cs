using UnityEngine;

public interface IRandomizer
{
    Color Color { get; }
    int Damage { get; }
    int Prize { get; }
    float Speed { get; }

    void Reset();
}