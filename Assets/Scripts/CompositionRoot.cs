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
        ScreenInformer screenInformer = FindObjectOfType<ScreenInformer>();
        screenInformer.Init();

        ScreenTopSpawnZone spawnLimiter = FindObjectOfType<ScreenTopSpawnZone>();
        spawnLimiter.Init(screenInformer);

        BalloonCreator creator = new BalloonCreator(_appSettings.Prefab, 
                                                    _spawnRoot);

        BalloonPool pool = new BalloonPool(creator, 
                                            _appSettings.PoolCapacity);

        RandomTimer timer = new RandomTimer(_appSettings.MinCreationTime, _appSettings.MaxCreationTime);

        Randomizer randomizer = new Randomizer(   
                                                    _appSettings.MaxPrize, 
                                                    _appSettings.MaxDamage, 
                                                    _appSettings.MinSpeed, 
                                                    _appSettings.MaxSpeed);

        RandomizerWithSpeedIncrease randomizerWithSpeedIncrease = new RandomizerWithSpeedIncrease(randomizer);
        randomizerWithSpeedIncrease.Increase = _appSettings.SpeedIncrease;

        Spawner spawner = FindObjectOfType<Spawner>();
        spawner.Init(pool,
                    timer,
                    randomizerWithSpeedIncrease, 
                    new SpawnerParams { 
                        MinTimeOut = _appSettings.MinCreationTime,
                        MaxTimeOut = _appSettings.MaxCreationTime,
                        CreationTimeDecrease = _appSettings.CreationTimeDecrease,
                        Acceleration = _appSettings.Acceleration}
                    );

        DownScreenLimiter limiter = FindObjectOfType<DownScreenLimiter>();
        limiter.Init(screenInformer);

        Score score = FindObjectOfType<Score>();
        score.Init(_appSettings.StartHealth, 
                    _appSettings.BestScoreKey);
    }
}