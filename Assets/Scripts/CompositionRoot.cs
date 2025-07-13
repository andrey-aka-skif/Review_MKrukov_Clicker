using UnityEngine;

public class CompositionRoot : MonoBehaviour
{
    [SerializeField] private AppSettings _appSettings;

    [SerializeField] private Transform _spawnRoot;

    private void Awake()
    {
        Compose();
    }

    public void Compose()
    {
        var screenInformer = FindFirstObjectByType<ScreenInformer>();
        screenInformer.Init();

        var spawnLimiter = FindFirstObjectByType<ScreenTopSpawnZone>();
        spawnLimiter.Init(screenInformer);

        var creator = new BalloonCreator(_appSettings.Prefab, _spawnRoot);

        var pool = new BalloonPool(creator, _appSettings.PoolCapacity);

        var timer = new RandomTimer(_appSettings.MinCreationTime, _appSettings.MaxCreationTime);

        var randomizer = new Randomizer(
            _appSettings.MaxPrize,
            _appSettings.MaxDamage,
            _appSettings.MinSpeed,
            _appSettings.MaxSpeed);

        var randomizerWithSpeedIncrease = new RandomizerWithSpeedIncrease(randomizer)
        {
            Increase = _appSettings.SpeedIncrease
        };

        var spawner = FindFirstObjectByType<Spawner>();
        spawner.Init(pool,
                    timer,
                    randomizerWithSpeedIncrease,
                    new SpawnerParams
                    {
                        MinTimeOut = _appSettings.MinCreationTime,
                        MaxTimeOut = _appSettings.MaxCreationTime,
                        CreationTimeDecrease = _appSettings.CreationTimeDecrease,
                        Acceleration = _appSettings.Acceleration
                    });

        var limiter = FindFirstObjectByType<DownScreenLimiter>();
        limiter.Init(screenInformer);

        var score = FindFirstObjectByType<Score>();
        score.Init(_appSettings.StartHealth,
                    _appSettings.BestScoreKey);
    }
}
