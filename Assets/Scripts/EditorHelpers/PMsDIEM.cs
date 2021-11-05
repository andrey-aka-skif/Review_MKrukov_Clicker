using UnityEngine;

#if UNITY_EDITOR

[ExecuteInEditMode]
public class PMsDIEM : MonoBehaviour
{
    private ScreenInformer _screenInformer;

    private ScreenTopSpawnZone _spawnZone;

    private DownScreenLimiter _downLimiter;

    private void Update()
    {
        if(_screenInformer == null)
        {
            _screenInformer = FindObjectOfType<ScreenInformer>();
        }
        _screenInformer.Init();

        if(_spawnZone == null)
        {
            _spawnZone = FindObjectOfType<ScreenTopSpawnZone>();
        }
        _spawnZone.Init(_screenInformer);

        if(_downLimiter == null)
        {
            _downLimiter = FindObjectOfType<DownScreenLimiter>();
        }
        _downLimiter.Init(_screenInformer);
    }
}

#endif