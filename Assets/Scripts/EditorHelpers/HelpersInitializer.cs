using UnityEngine;

#if UNITY_EDITOR

[ExecuteInEditMode]
public class HelpersInitializer : MonoBehaviour
{
    private ScreenInformer _screenInformer;

    private ScreenTopSpawnZone _spawnZone;

    private DownScreenLimiter _downLimiter;

    private void Update()
    {
        if (_screenInformer == null)
        {
            _screenInformer = FindFirstObjectByType<ScreenInformer>();
        }
        _screenInformer.Init();

        if (_spawnZone == null)
        {
            _spawnZone = FindFirstObjectByType<ScreenTopSpawnZone>();
        }
        _spawnZone.Init(_screenInformer);

        if (_downLimiter == null)
        {
            _downLimiter = FindFirstObjectByType<DownScreenLimiter>();
        }
        _downLimiter.Init(_screenInformer);
    }
}

#endif
