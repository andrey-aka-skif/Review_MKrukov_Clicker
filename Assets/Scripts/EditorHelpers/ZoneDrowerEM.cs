using UnityEngine;

#if UNITY_EDITOR

[ExecuteInEditMode]
public class ZoneDrowerEM : MonoBehaviour
{
    [SerializeField] private Color _color = Color.red;

    private IZoned _zoner;

    private void OnDrawGizmos()
    {
        if(_zoner == null)
        {
            _zoner = GetZoned();
        }

        Gizmos.color = _color;
        Gizmos.DrawWireCube(_zoner.Center, _zoner.Size);
    }

    private IZoned GetZoned()
    {
        IZoned zoner = GetComponent<IZoned>();
        if (zoner == null)
        {
            throw new System.NullReferenceException("Отсутствует компонент, реализующий IZoned");
        }
        return zoner;
    }
}

#endif