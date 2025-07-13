
/// <summary>
/// Параметры настройки спаунера
/// </summary>
public struct SpawnerParams
{
    /// <summary>
    /// Минимальный таймаут спавна
    /// </summary>
    public float MinTimeOut { get; set; }

    /// <summary>
    /// Максимальный таймаут спавна
    /// </summary>
    public float MaxTimeOut { get; set; }

    /// <summary>
    /// Уменьшение времени спавна
    /// </summary>
    public float CreationTimeDecrease { get; set; }

    /// <summary>
    /// Ускорение шара
    /// </summary>
    public float Acceleration { get; set; }
}
