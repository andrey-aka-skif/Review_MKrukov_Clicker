using UnityEngine;

public class ScreenInformer : MonoBehaviour
{
    private float _leftLimit;
    private float _rightLimit;
    private float _topLimit;
    private float _bottomLimit;

    private float _screenWidth;
    private float _screenHeight;

    public float SceneLeftLimit => _leftLimit;
    public float SceneRightLimit => _rightLimit;
    public float SceneTopLimit => _topLimit;
    public float SceneBottomLimit => _bottomLimit;

    public float SceneWidth => _screenWidth;
    public float SceneHeight => _screenHeight;

    public void Init()
    {
        GetInfo();
    }

    private void GetInfo()
    {
        float cameraZ = Mathf.Abs(Camera.main.transform.position.z);

        Vector3 leftBottomFramePoint = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, cameraZ));
        Vector3 rightTopFramePoint = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, cameraZ));

        _leftLimit = leftBottomFramePoint.x;
        _rightLimit = rightTopFramePoint.x;
        _topLimit = rightTopFramePoint.y;
        _bottomLimit = leftBottomFramePoint.y;

        _screenWidth = rightTopFramePoint.x - leftBottomFramePoint.x;
        _screenHeight = rightTopFramePoint.y - leftBottomFramePoint.y;
    }
}