#if UNITY_EDITOR
using System;
using UnityEngine;

namespace Assets.Project.Scripts.ScreenHelpers.EditorOnly
{
    /// <summary>
    /// Компонент инспектора, рисующий зону в форме параллелепипеда
    /// </summary>
    [ExecuteInEditMode]
    public class EditorOnlyZoneDrower : MonoBehaviour
    {
        [SerializeField]
        private Color _color = Color.red;

        private IZoned _drawnZone;

        private void OnDrawGizmos()
        {
            _drawnZone ??= GetDrawnZone();

            Gizmos.color = _color;
            Gizmos.DrawWireCube(_drawnZone.Center, _drawnZone.Size);
        }

        private IZoned GetDrawnZone()
        {
            if (TryGetComponent<IZoned>(out var zone))
                return zone;

            throw new NullReferenceException($"Отсутствует компонент, реализующий {nameof(IZoned)}");
        }
    }
}
#endif
