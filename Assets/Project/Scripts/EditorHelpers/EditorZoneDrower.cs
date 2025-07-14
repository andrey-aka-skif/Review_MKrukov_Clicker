using System;
using UnityEngine;

#if UNITY_EDITOR

/// <summary>
/// Компонент, рисующий зоны в инспекторе
/// </summary>
[ExecuteInEditMode]
public class EditorZoneDrower : MonoBehaviour
{
    [SerializeField] 
    private Color _color = Color.red;

    private IZoned _zoner;

    private void OnDrawGizmos()
    {
        _zoner ??= GetZoned();

        Gizmos.color = _color;
        Gizmos.DrawWireCube(_zoner.Center, _zoner.Size);
    }

    private IZoned GetZoned()
    {
        if (!TryGetComponent<IZoned>(out var zoner))
        {
            throw new NullReferenceException("Отсутствует компонент, реализующий IZoned");
        }
        return zoner;
    }
}

#endif
