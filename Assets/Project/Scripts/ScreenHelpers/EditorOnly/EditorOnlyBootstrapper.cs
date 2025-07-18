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

        private void OnEnable() => EditorApplication.update += ReInitComponents;

        private void OnDisable() => EditorApplication.update -= ReInitComponents;

        private void ReInitComponents()
        {
            _screenInformer ??= new ScreenSizeInformer(Camera.main);
            _screenInformer.Calculate();

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
