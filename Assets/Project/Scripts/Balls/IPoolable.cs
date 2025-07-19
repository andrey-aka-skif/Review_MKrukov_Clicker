/// <summary>
/// Объект, который может быть использован в пуле
/// </summary>
/// <remarks>
/// Оборачивает <seealso cref="IActivatable{TSettings}"/> для явного указания на использование в пуле
/// </remarks>
public interface IPoolable<TSettings> : IActivatable<TSettings> { }

public interface IPoolable : IActivatable { }
