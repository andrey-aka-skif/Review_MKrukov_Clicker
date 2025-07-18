using UnityEngine;

namespace Assets.Project.Scripts.ScreenHelpers
{

    /// <summary>
    /// Помощник, предоставляющий информацию о размере экрана
    /// </summary>
    public class ScreenInformer : MonoBehaviour
    {
        private float _leftLimit;
        private float _rightLimit;
        private float _topLimit;
        private float _bottomLimit;

        private float _screenWidth;
        private float _screenHeight;

        /// <summary>
        /// Ограничение экрана слева
        /// </summary>
        public float SceneLeftLimit => _leftLimit;

        /// <summary>
        /// Ограничение экрана справа
        /// </summary>
        public float SceneRightLimit => _rightLimit;

        /// <summary>
        /// Ограничение экрана сверху
        /// </summary>
        public float SceneTopLimit => _topLimit;

        /// <summary>
        /// Ограничение экрана снизу
        /// </summary>
        public float SceneBottomLimit => _bottomLimit;

        /// <summary>
        /// Ширина экрана
        /// </summary>
        public float SceneWidth => _screenWidth;

        /// <summary>
        /// Высота экрана
        /// </summary>
        public float SceneHeight => _screenHeight;

        /// <summary>
        /// Инициализировать информер
        /// </summary>
        public void Init() => GetInfo();

        private void GetInfo()
        {
            var cameraZ = Mathf.Abs(Camera.main.transform.position.z);

            var leftBottomFramePoint = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, cameraZ));
            var rightTopFramePoint = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, cameraZ));

            _leftLimit = leftBottomFramePoint.x;
            _rightLimit = rightTopFramePoint.x;
            _topLimit = rightTopFramePoint.y;
            _bottomLimit = leftBottomFramePoint.y;

            _screenWidth = rightTopFramePoint.x - leftBottomFramePoint.x;
            _screenHeight = rightTopFramePoint.y - leftBottomFramePoint.y;
        }
    }
}
