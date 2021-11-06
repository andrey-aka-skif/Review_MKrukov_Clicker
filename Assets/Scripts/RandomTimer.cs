using UnityEngine;
using Random = System.Random;

public sealed class RandomTimer
{
    private const float MIN_TIMEOUT_DEFAULT = 0.5f;
    private const float MAX_TIMEOUT_DEFAULT = 2.5f;

    private readonly Random _rnd = new Random();

    private readonly float _minTimeout;
    private readonly float _maxTimeout;
    
    private float _timeout;
    private float _lastUpdate;

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