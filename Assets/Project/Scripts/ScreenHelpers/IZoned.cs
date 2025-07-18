using UnityEngine;

namespace Assets.Project.Scripts.ScreenHelpers
{
    /// <summary>
    /// Зона
    /// </summary>
    public interface IZoned
    {
        /// <summary>
        /// Центр зоны
        /// </summary>
        Vector3 Center { get; }

        /// <summary>
        /// Размер зоны
        /// </summary>
        Vector3 Size { get; }
    }
}
