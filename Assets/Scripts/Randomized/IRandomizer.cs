using UnityEngine;

/// <summary>
/// Рандомайзер для получения случайных характеристик шара
/// </summary>
public interface IRandomizer
{
    /// <summary>
    /// Цвет шара
    /// </summary>
    Color Color { get; }

    /// <summary>
    /// Урон от шара
    /// </summary>
    int Damage { get; }

    /// <summary>
    /// Ценность шара
    /// </summary>
    int Prize { get; }

    /// <summary>
    /// Начальная скорость шара
    /// </summary>
    float Speed { get; }

    /// <summary>
    /// Сбросить рандомайзер
    /// </summary>
    void Reset();
}
