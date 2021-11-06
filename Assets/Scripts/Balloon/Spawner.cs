using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float _minTimeoutDefault;
    private float _maxTimeoutDefault;

    private float _creationTimeDecrease;
    private float _acceleration;

    private RandomTimer _timer;

    private IRandomizer _randomizer;

    private ISpawnZone _spawnZone;
    private BalloonPool _pool;

    private readonly List<Balloon> _spawned = new List<Balloon>();

    [SerializeField] private AddScoreEvent ScoreAdded;
    [SerializeField] private AddDamageEvent DamageAdded;

    public void Init(BalloonPool pool, RandomTimer timer, IRandomizer randomizer, SpawnerParams param)
    {
        _pool = pool;
        _timer = timer;
        _randomizer = randomizer;

        _creationTimeDecrease = param.CreationTimeDecrease;
        _acceleration = param.Acceleration;

        _minTimeoutDefault = _timer.MinTimeout;
        _maxTimeoutDefault = _timer.MaxTimeOut;

        _spawnZone = transform.GetComponent<ISpawnZone>();
        if (_spawnZone == null)
        {
            throw new ArgumentNullException("Не найден компонент, реализующий ISpawnZone");
        }

        Restart();
    }

    public void Restart()
    {
        ScoreAdded ??= new AddScoreEvent();
        DamageAdded ??= new AddDamageEvent();

        _randomizer.Reset();

        _timer.MinTimeout = _minTimeoutDefault;
        _timer.MaxTimeOut = _maxTimeoutDefault;

        ReturnAllInPool();
    }

    private void Update()
    {
        if (_timer.Dropped)
        {
            CreateBalloon();

            _timer.MinTimeout -= _creationTimeDecrease;
            _timer.MaxTimeOut -= _creationTimeDecrease;
        }
    }

    public void OnBalloonDestroyed(Balloon balloon)
    {
        if (_spawned.Contains(balloon))
        {
            _spawned.Remove(balloon);
        }

        balloon.Clicked.RemoveListener(OnBalloonClicked);
        balloon.BorderTouched.RemoveListener(OnBalloonTouchedBorder);
        balloon.Destroyed.RemoveListener(OnBalloonDestroyed);

        _pool.ReturnElement(balloon);
    }

    public void OnBalloonClicked(Balloon balloon)
    {
        ScoreAdded?.Invoke(balloon.Prize);
    }

    public void OnBalloonTouchedBorder(Balloon balloon)
    {
        DamageAdded?.Invoke(balloon.Damage);
    }

    private void ReturnAllInPool()
    {
        foreach (Balloon item in _spawned)
        {
            _pool.ReturnElement(item);
        }
    }

    private void CreateBalloon()
    {
        Balloon balloon = _pool.GetElement();
        balloon.Activate(GetSettings());
        balloon.Clicked.AddListener(OnBalloonClicked);
        balloon.BorderTouched.AddListener(OnBalloonTouchedBorder);
        balloon.Destroyed.AddListener(OnBalloonDestroyed);

        _spawned.Add(balloon);
    }

    private BalloonSettings GetSettings()
    {
        return new BalloonSettings
        {
            Position = _spawnZone.GetRndPosition(),
            Scale = new Vector3(1, 1, 1),
            Color = _randomizer.Color,
            Speed = _randomizer.Speed,
            Acceleration = _acceleration,
            PrizePoints = _randomizer.Prize,
            PlayerDamagePoints = _randomizer.Damage
        };
    }
}