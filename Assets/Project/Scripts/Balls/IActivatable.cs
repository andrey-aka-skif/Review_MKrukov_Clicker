/// <summary>
/// Объект, который может быть активирован и деактивирован
/// </summary>
public interface IActivatable<TSettings>
{
    /// <summary>
    /// Иктивен ли объект
    /// </summary>
    bool IsActive { get; }

    /// <summary>
    /// Активировать объект
    /// </summary>
    /// <param name="settings">
    /// Объект настроек, с которыми создается объект
    /// </param>
    void Activate(TSettings settings);

    /// <summary>
    /// Деактивировать объект
    /// </summary>
    void Deactivate();
}

public interface IActivatable
{
    bool IsActive { get; }

    void Activate();
    void Deactivate();
}
