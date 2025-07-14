/// <summary>
/// Объект, который может быть использован в пуле
/// </summary>
public interface IPoolable
{
    /// <summary>
    /// Активировать объект
    /// </summary>
    /// <param name="settings">
    /// Объект настроек, с которыми создается объект пула
    /// </param>
    void Activate(BalloonSettings settings);

    /// <summary>
    /// Деактивировать объект
    /// </summary>
    void Deactivate();
}
