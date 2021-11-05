using System;
using UnityEngine;

[RequireComponent(typeof(SpawnRandomizer))]
public class Spawner : MonoBehaviour
{
    [SerializeField] float _minTimeOut = 1;
    [SerializeField] float _maxTimeOut = 5;

    private RandomTimer _timer;

    private SpawnRandomizer _randomizer;

    private ISpawnZone _spawnZone;
    private BalloonPool _pool;

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

    public void Init(BalloonPool pool, float minTimeOut = 1, float maxTimeOut = 5)
    {
        _pool = pool;

        _minTimeOut = minTimeOut;
        _maxTimeOut = maxTimeOut;

        _timer = new RandomTimer(_minTimeOut, _maxTimeOut);

        _spawnZone = transform.GetComponent<ISpawnZone>();
        if (_spawnZone == null)
        {
            throw new ArgumentNullException("Не найден компонент, реализующий ISpawnZone");
        }

        _randomizer = transform.GetComponent<SpawnRandomizer>();
        if (_randomizer == null)
        {
            throw new ArgumentNullException("Не найден компонент SpawnRandomizer");
        }
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
        Debug.Log("OnBalloonDestroyed");
        _pool.ReturnElement(balloon);
    }

    public void OnBalloonClicked(Balloon balloon)
    {
        Debug.Log($"OnBalloonClicked. +{balloon.PrizePoints} points");
    }

    public void OnBalloonTouchedBorder(Balloon balloon)
    {
        Debug.Log($"OnBalloonTouchedBorder. -{balloon.PlayerDamagePoints} hp");
    }

    private void CreateBalloon()
    {
        Balloon balloon = _pool.GetElement();
        balloon.SetState(GetSettings());
        balloon.Clicked.AddListener(OnBalloonClicked);
        balloon.BorderTouched.AddListener(OnBalloonTouchedBorder);

        BalloonBehaviour behaviour = balloon.GetComponent<BalloonBehaviour>();
        behaviour.Destroyed.AddListener(OnBalloonDestroyed);
    }

    private BalloonSettings GetSettings()
    {
        return new BalloonSettings
        {
            Position = _spawnZone.GetRndPosition(),
            Scale = new Vector3(1, 1, 1),
            Color = _randomizer.Color,
            Speed = _randomizer.Speed,
            PrizePoints = _randomizer.PrizePoints,
            PlayerDamagePoints = _randomizer.PlayerDamagePoints
        };
    }
}