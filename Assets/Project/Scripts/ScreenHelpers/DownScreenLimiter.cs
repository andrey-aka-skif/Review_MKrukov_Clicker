using UnityEngine;

namespace Assets.Project.Scripts.ScreenHelpers
{

    /// <summary>
    /// Ограничитель зоны движения шаров
    /// </summary>
    [RequireComponent(typeof(BoxCollider))]
    public class DownScreenLimiter : MonoBehaviour, IZoned, ILimit
    {
        [SerializeField]
        private float _thickness = 1;

        [SerializeField]
        private float _shiftVertical = -.1f;

        [SerializeField]
        private float _margin = 1;

        private const float DEEP_BY_Z = 1.0f;
        private const float POSITION_X = 0;
        private const float POSITION_Z = 0;

        private ScreenInformer _screen;

        public Vector3 Center { get; private set; }
        public Vector3 Size { get; private set; }

        /// <summary>
        /// Инициализировать ограничитель
        /// </summary>
        /// <param name="screen">
        /// Помощник, предоставляющий информацию о размере экрана
        /// </param>
        public void Init(ScreenInformer screen)
        {
            _screen = screen;

            Place();
            SetCollider();
        }

        private void Place()
        {
            Center = new Vector3(POSITION_X, GetYPosition(), POSITION_Z);
            transform.position = Center;
        }

        private void SetCollider()
        {
            Size = new Vector3(GetWidth(), _thickness, GetDeep());
            var collider = GetComponent<BoxCollider>();
            collider.isTrigger = true;
            collider.size = Size;
        }

        private float GetYPosition() => _screen.SceneBottomLimit + _shiftVertical;

        private float GetWidth() => _screen.SceneWidth + _margin;

        private float GetDeep() => DEEP_BY_Z + _margin;
    }
}
