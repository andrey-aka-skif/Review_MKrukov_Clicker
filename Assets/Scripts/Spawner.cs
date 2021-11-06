using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float _minTimeOut = 1;
    private float _maxTimeOut = 5;
    private float _acceleration = .01f;

    private RandomTimer _timer;

    private SpawnRandomizer _randomizer;

    private ISpawnZone _spawnZone;
    private BalloonPool _pool;

    private readonly List<Balloon> _spawned = new List<Balloon>();

    public float MinTimeOut
    {
        get => _minTimeOut;
        set
        {
            _minTimeOut = value > 0 ? value : 0;
            _minTimeOut = value < _maxTimeOut ? value : _maxTimeOut;
            _timer = new RandomTimer(_minTimeOut, _maxTimeOut);
        }
    }

    public float MaxTimeOut
    {
        get => _maxTimeOut;
        set
        {
            _maxTimeOut = value > 0 ? value : 0;
            _maxTimeOut = value > _minTimeOut ? value : _minTimeOut;
            _timer = new RandomTimer(_minTimeOut, _maxTimeOut);
        }
    }

    [SerializeField] private AddScoreEvent ScoreAdded;
    [SerializeField] private AddDamageEvent DamageAdded;

    public void Init(BalloonPool pool, SpawnRandomizer randomizer, float minTimeOut = 1, float maxTimeOut = 5, float acceleration = .01f)
    {
        _pool = pool;
        _randomizer = randomizer;

        _minTimeOut = minTimeOut;
        _maxTimeOut = maxTimeOut;
        _acceleration = acceleration;

        _timer = new RandomTimer(_minTimeOut, _maxTimeOut);

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

        ReturnAllInPool();
    }

    private void Update()
    {
        if (_timer.Dropped)
        {
            CreateBalloon();
        }        
    }

    public void OnBalloonDestroyed(Balloon balloon)
    {
        if(_spawned.Contains(balloon))
        {
            _spawned.Remove(balloon);
        }

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
        balloon.Destroyed.AddListener (OnBalloonDestroyed);

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