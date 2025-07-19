using UnityEngine;

/// <summary>
/// Настройки шара при активации
/// </summary>
public struct BallSettings
{
    /// <summary>
    /// Позиция
    /// </summary>
    public Vector3 Position { get; set; }

    /// <summary>
    /// Размер
    /// </summary>
    public Vector3 Scale { get; set; }

    /// <summary>
    /// Цвет
    /// </summary>
    public Color Color { get; set; }

    /// <summary>
    /// Скорость
    /// </summary>
    public float Speed { get; set; }

    /// <summary>
    /// Ускорение
    /// </summary>
    public float Acceleration { get; set; }

    /// <summary>
    /// Очки
    /// </summary>
    public int PrizePoints { get; set; }

    /// <summary>
    /// Урон
    /// </summary>
    public int PlayerDamagePoints { get; set; }
}
