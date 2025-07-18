#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Assets.Project.Scripts.ScreenHelpers.EditorOnly
{
    /// <summary>
    /// Компонент инспектора, инициализирующий скрипты
    /// для отображения в инспекторе зон спауна и лимитера
    /// </summary>
    [ExecuteInEditMode]
    public class EditorOnlyBootstrapper : MonoBehaviour
    {
        private ScreenSizeInformer _screenInformer;
        private ScreenTopSpawnZone _spawnZone;
        private ScreenDownLimiter _downLimiter;

        private void OnEnable() => EditorApplication.update += InitComponents;

        private void OnDisable() => EditorApplication.update -= InitComponents;

        private void InitComponents()
        {
            if (_screenInformer == null)
            {
                _screenInformer = FindFirstObjectByType<ScreenSizeInformer>();
            }
            _screenInformer.Init();

            if (_spawnZone == null)
            {
                _spawnZone = FindFirstObjectByType<ScreenTopSpawnZone>();
            }
            _spawnZone.Init(_screenInformer);

            if (_downLimiter == null)
            {
                _downLimiter = FindFirstObjectByType<ScreenDownLimiter>();
            }
            _downLimiter.Init(_screenInformer);
        }
    }
}
#endif
