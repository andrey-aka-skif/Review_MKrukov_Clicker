using Assets.Project.Scripts.GameManagement;
using Assets.Project.Scripts.ScreenHelpers;
using Assets.Project.Scripts.UI;
using System;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField]
    private AppSettings _appSettings;

    [SerializeField]
    private Transform _spawnRoot;

    private void Awake()
    {
        var gameState = new GameState();
        var gameTimeController = FindFirstObjectByTypeOrAdd<GameTimeController>();
        gameTimeController.Init(gameState);

        gameState.Stop();

        var scoreSaver = new BestScoreSaver();
        var score = new GameScore(scoreSaver);

        var uiManager = FindFirstObjectByTypeOrThrow<UIManager>();
        uiManager.Init(gameState, score);
        uiManager.ShowStartMenu();

        var screenInformer = new ScreenSizeInformer(Camera.main);
        screenInformer.Calculate();

        var spawnZone = FindFirstObjectByType<ScreenTopSpawnZone>();
        spawnZone.Init(screenInformer);

        var limitZone = FindFirstObjectByType<ScreenDownLimiter>();
        limitZone.Init(screenInformer);

        Compose();
    }

    private void Compose()
    {
        var creator = new BalloonCreator(_appSettings.Prefab, _spawnRoot);

        var pool = new BalloonPool(creator, _appSettings.PoolCapacity);

        var timer = new RandomTimer(_appSettings.MinCreationTime, _appSettings.MaxCreationTime);

        var randomizer = new Randomizer(
            _appSettings.MaxPrize,
            _appSettings.MaxDamage,
            _appSettings.MinSpeed,
            _appSettings.MaxSpeed);

        var randomizerWithSpeedIncrease = new AcceleratingRandomizerDecorator(randomizer)
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

    }

    private T FindFirstObjectByTypeOrThrow<T>() where T : Component
    {
        var obj = FindFirstObjectByType<T>();
        return obj ?? throw new NullReferenceException();
    }

    private T FindFirstObjectByTypeOrAdd<T>(GameObject parent = null) where T : Component
    {
        var instance = FindFirstObjectByType<T>();

        if (instance != null)
            return instance;

        if (parent == null)
            parent = gameObject;

        return parent.AddComponent<T>();
    }
}
