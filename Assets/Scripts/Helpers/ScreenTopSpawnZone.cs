using UnityEngine;
using Random = System.Random;

public class ScreenTopSpawnZone : MonoBehaviour, ISpawnZone
{
    [SerializeField] private float _leftFramePadding = 0;
    [SerializeField] private float _rightFramePadding = 0;
    [SerializeField] private float _topFramePadding = 0;

    [SerializeField] private float _spawnHeightInFramePercent = 25;

    private const float DEEP_BY_Z = 1.0f;
    private const float POSITION_Z = 0;

    private ScreenInformer _screen;

    private readonly Random _rnd = new Random();

    public Vector3 Center { get; private set; }
    public Vector3 Size { get; private set; }

    public void Init(ScreenInformer screen)
    {
        _screen = screen;

        Calculate();
    }

    public Vector3 GetRndPosition()
    {
        float rndX = (float)(_rnd.NextDouble() * (GetRightLimit() - GetLeftLimit()) + GetLeftLimit());
        float rndY = (float)(_rnd.NextDouble() * (GetTopLimit() - GetBottomLimit()) + GetBottomLimit());

        return new Vector3(rndX, rndY);
    }

    private void Calculate()
    {
        Center = new Vector3(
            (GetLeftLimit() + GetRightLimit()) / 2,
            (GetTopLimit() + GetBottomLimit()) / 2,
            POSITION_Z);

        Size =  new Vector3(
            GetRightLimit() - GetLeftLimit(),
            GetTopLimit() - GetBottomLimit(),
            DEEP_BY_Z);
    }

    private float GetLeftLimit() => _screen.SceneLeftLimit + _leftFramePadding;

    private float GetRightLimit() => _screen.SceneRightLimit - _rightFramePadding;

    private float GetTopLimit() => _screen.SceneTopLimit - _topFramePadding;

    private float GetBottomLimit() => GetTopLimit() - _screen.SceneHeight * _spawnHeightInFramePercent / 100;
}