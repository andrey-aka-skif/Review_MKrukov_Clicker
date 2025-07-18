using System;
using UnityEngine;

namespace Assets.Project.Scripts.ScreenHelpers
{
    /// <summary>
    /// Ограничитель зоны движения шаров
    /// </summary>
    /// <remarks>
    /// Располагается снизу экрана
    /// </remarks>
    [RequireComponent(typeof(BoxCollider))]
    public class ScreenDownLimiter : MonoBehaviour, IZoned, ILimit
    {
        [SerializeField]
        private float _thickness = 1f;

        [SerializeField]
        private float _shiftVertical = 0f;

        [SerializeField]
        private float _marginSide = -1f;

        private const float DEEP_BY_Z = 1.0f;
        private const float POSITION_Z = 0;

        private ScreenSizeInformer _screen;

        public Vector3 Center { get; private set; }
        public Vector3 Size { get; private set; }

        /// <summary>
        /// Инициализировать ограничитель
        /// </summary>
        /// <param name="screen">
        /// Помощник, предоставляющий информацию о размере экрана
        /// </param>
        public void Init(ScreenSizeInformer screen)
        {
            _screen = screen;
            Calculate();
            Place();
            SetCollider();
        }

        private void Calculate()
        {
            Center = new Vector3(
                (_screen.WorldBoundaryLeft + _screen.WorldBoundaryRight) / 2,
                _screen.WorldBoundaryBottom + _shiftVertical - _thickness / 2,
                POSITION_Z);

            Size = new Vector3(
                _screen.WorldWidth - _marginSide,
                _thickness,
                DEEP_BY_Z - _marginSide);
        }

        private void Place() => transform.position = Center;

        private void SetCollider()
        {
            var collider = GetComponent<BoxCollider>();
            collider.isTrigger = true;
            collider.size = Size;
        }
    }
}
