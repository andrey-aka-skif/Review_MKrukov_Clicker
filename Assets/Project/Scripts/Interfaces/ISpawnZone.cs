using UnityEngine;
/// <summary>
/// Зона спауна
/// </summary>
public interface ISpawnZone : IZoned
{
    /// <summary>
    /// Вернуть случайную позицию внутри зоны спауна
    /// </summary>
    /// <returns></returns>
    Vector3 GetRndPosition();
}
