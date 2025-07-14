using UnityEngine;
using Random = System.Random;

public sealed class RandomTimer
{
    private const float MIN_TIMEOUT = 0.1f;

    private const float MIN_TIMEOUT_DEFAULT = 0.5f;
    private const float MAX_TIMEOUT_DEFAULT = 2.5f;

    private readonly Random _rnd = new();

    private float _minTimeout;
    private float _maxTimeout;

    private float _timeout;
    private float _lastUpdate;

    public float MinTimeout
    {
        get => _minTimeout;
        set
        {
            _minTimeout = value > MIN_TIMEOUT ? value : MIN_TIMEOUT;
            _minTimeout = _minTimeout < _maxTimeout ? _minTimeout : _maxTimeout;
        }
    }

    public float MaxTimeOut
    {
        get => _maxTimeout;
        set
        {
            _maxTimeout = value > _minTimeout ? value : _minTimeout;
        }
    }

    public RandomTimer(float minTimeout = MIN_TIMEOUT_DEFAULT, float maxTimeout = MAX_TIMEOUT_DEFAULT)
    {
        _minTimeout = minTimeout;
        _maxTimeout = maxTimeout;
    }

    public void Reset()
    {
        _lastUpdate = Time.time;
        _timeout = GetRndTimeout();
    }

    public bool Dropped
    {
        get
        {
            if (Time.time - _lastUpdate > _timeout)
            {
                _lastUpdate = Time.time;
                _timeout = GetRndTimeout();
                return true;
            }
            return false;
        }
    }

    private float GetRndTimeout()
    {
        return (float)(_rnd.NextDouble() * (_maxTimeout - _minTimeout) + _minTimeout);
    }
}
