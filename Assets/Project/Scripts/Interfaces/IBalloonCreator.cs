/// <summary>
/// Создатель шара
/// </summary>
public interface IBalloonCreator
{
    /// <summary>
    /// Создать шар
    /// </summary>
    /// <param name="number">
    /// Идентификатор, который будет добавлен к имени GameObject шара
    /// для уникального имени в инспекторе
    /// </param>
    /// <returns>Шар</returns>
    Balloon Create(int number);
}
