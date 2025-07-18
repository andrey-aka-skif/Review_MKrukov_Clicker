using UnityEngine;

namespace Assets.Project.Scripts.ScreenHelpers
{
    /// <summary>
    /// Компонент инспектора, предоставляющий информацию 
    /// о размере экрана в единицах сцены
    /// </summary>
    public class ScreenSizeInformer
    {
        private readonly Camera _camera;

        public ScreenSizeInformer(Camera camera)
        {
            if (camera == null)
                throw new System.NullReferenceException("В сцене отсутствует камера");

            _camera = camera;
        }

        /// <summary>
        /// Ширина экрана в единицах сцены
        /// </summary>
        public float WorldWidth { get; private set; }

        /// <summary>
        /// Высота экрана в единицах сцены
        /// </summary>
        public float WorldHeight { get; private set; }

        /// <summary>
        /// Левая граница экрана в координатах сцены
        /// </summary>
        public float WorldBoundaryLeft { get; private set; }

        /// <summary>
        /// Правая граница экрана в координатах сцены
        /// </summary>
        public float WorldBoundaryRight { get; private set; }

        /// <summary>
        /// Верхняя граница экрана в координатах сцены
        /// </summary>

        public float WorldBoundaryTop { get; private set; }

        /// <summary>
        /// Нижняя граница экрана в координатах сцены
        /// </summary>
        public float WorldBoundaryBottom { get; private set; }

        /// <summary>
        /// Пересчитать
        /// </summary>
        public void Calculate()
        {
            var cameraZ = Mathf.Abs(_camera.transform.position.z);

            var leftBottomFramePoint = _camera.ViewportToWorldPoint(new Vector3(0, 0, cameraZ));
            var rightTopFramePoint = _camera.ViewportToWorldPoint(new Vector3(1, 1, cameraZ));

            WorldBoundaryLeft = leftBottomFramePoint.x;
            WorldBoundaryRight = rightTopFramePoint.x;
            WorldBoundaryTop = rightTopFramePoint.y;
            WorldBoundaryBottom = leftBottomFramePoint.y;

            WorldWidth = rightTopFramePoint.x - leftBottomFramePoint.x;
            WorldHeight = rightTopFramePoint.y - leftBottomFramePoint.y;
        }
    }
}
