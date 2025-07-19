using Assets.Project.Scripts.GameManagement;
using System;

public class BallsSystem : IPausable, ITicked
{
    private readonly Pool<Ball, BallSettings> _pool;
    private readonly Spawner _spawner;
    private readonly GameScore _gameScore;

    public BallsSystem(Pool<Ball, BallSettings> pool, Spawner spawner, GameScore gameScore)
    {
        _pool = pool;
        _spawner = spawner;
        _gameScore = gameScore;
    }

    public bool IsPaused => !IsPlaying;

    public bool IsPlaying { get; private set; }

    public void Pause()
    {
        throw new NotImplementedException();
    }

    public void Restart()
    {
        throw new NotImplementedException();
    }

    public void Play()
    {
        throw new NotImplementedException();
    }

    public void Stop()
    {
        throw new NotImplementedException();
    }

    public void Tick(float deltaTime)
    {
        throw new NotImplementedException();
    }
}
