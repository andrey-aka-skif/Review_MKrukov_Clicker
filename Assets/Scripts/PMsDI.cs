using UnityEngine;


public class PMsDI : MonoBehaviour
{
    [SerializeField] private Balloon _prefab;
    [SerializeField] private Transform _spawnRoot;
    [SerializeField] private float _minTimeOut = 1;
    [SerializeField] private float _maxTimeOut = 5;
    [SerializeField] private float _acceleration = .01f;
    [SerializeField] private int _poolCapacity = 10;
    [SerializeField] private ScoreStorage _storage;

    private ScreenInformer _screenInformer;
    private ScreenTopSpawnZone _spawnLimiter;
    private BalloonCreator _creator;
    private BalloonPool _pool;
    private Spawner _spawner;
    private DownScreenLimiter _limiter;
    private Menu _menu;
    private Score _score;

    private void Awake()
    {
        Compose();
    }

    public void Compose()
    {
        _screenInformer = FindObjectOfType<ScreenInformer>();
        _screenInformer.Init();

        _spawnLimiter = FindObjectOfType<ScreenTopSpawnZone>();
        _spawnLimiter.Init(_screenInformer);

        _creator = new BalloonCreator(_prefab, _spawnRoot);

        _pool = new BalloonPool(_creator, _poolCapacity);

        _spawner = FindObjectOfType<Spawner>();
        _spawner.Init(_pool, _minTimeOut, _maxTimeOut);

        _limiter = FindObjectOfType<DownScreenLimiter>();
        _limiter.Init(_screenInformer);

        _menu = FindObjectOfType<Menu>();
        _menu.Init(this);

        _score = FindObjectOfType<Score>();
        _score.Init(_storage);
    }
}