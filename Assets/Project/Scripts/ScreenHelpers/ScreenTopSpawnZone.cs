using UnityEngine;
using Random = System.Random;

namespace Assets.Project.Scripts.ScreenHelpers
{
    /// <summary>
    /// Зона спауна шаров
    /// </summary>
    /// <remarks>
    /// Располагается вверху экрана
    /// </remarks>
    public class ScreenTopSpawnZone : MonoBehaviour, ISpawnZone
    {
        [SerializeField]
        private float _screenMarginLeft = .5f;

        [SerializeField]
        private float _screenMarginRight = .5f;

        [SerializeField]
        private float _screenMarginTop = 0;

        [SerializeField]
        private float _heightInFramePercent = 25f;

        private const float DEEP_BY_Z = 1.0f;
        private const float POSITION_Z = 0;

        private ScreenSizeInformer _screen;

        private readonly Random _rnd = new();

        public Vector3 Center { get; private set; }
        public Vector3 Size { get; private set; }

        public void Init(ScreenSizeInformer screen)
        {
            _screen = screen;
            Calculate();
            Place();
        }

        public Vector3 GetRndPosition()
        {
            return new Vector3(
                (float)(_rnd.NextDouble() * (WorldBoundaryRight - WorldBoundaryLeft) + WorldBoundaryLeft),
                (float)(_rnd.NextDouble() * (WorldBoundaryTop - WorldBoundaryBottom) + WorldBoundaryBottom));
        }

        private void Calculate()
        {
            Center = new Vector3(
                (WorldBoundaryLeft + WorldBoundaryRight) / 2,
                (WorldBoundaryTop + WorldBoundaryBottom) / 2,
                POSITION_Z);

            Size = new Vector3(
                WorldBoundaryRight - WorldBoundaryLeft,
                WorldBoundaryTop - WorldBoundaryBottom,
                DEEP_BY_Z);
        }

        private void Place() => transform.position = Center;

        private float WorldBoundaryLeft => _screen.WorldBoundaryLeft + _screenMarginLeft;

        private float WorldBoundaryRight => _screen.WorldBoundaryRight - _screenMarginRight;

        private float WorldBoundaryTop => _screen.WorldBoundaryTop - _screenMarginTop;

        private float WorldBoundaryBottom => WorldBoundaryTop - _screen.WorldHeight * _heightInFramePercent / 100;
    }
}
