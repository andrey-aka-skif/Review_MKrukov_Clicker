/// <summary>
/// Создатель шара
/// </summary>
public interface IItemCreator<T>
{
    /// <summary>
    /// Создать объект
    /// </summary>
    /// <param name="number">
    /// Идентификатор, который будет добавлен к имени GameObject объекта
    /// для уникального имени в инспекторе
    /// </param>
    /// <returns>Объект</returns>
    T Create(int number);
}
