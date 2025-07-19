using Assets.Project.Scripts.GameManagement;
using System;
using UnityEngine;

public class Ball : IPoolable<BallSettings>, IPausable, IDamageable, ISelectable, ITicked
{
    private float _acceleration;

    public event Action<Vector3> PositionChanged;
    public event Action<Ball> Clicked;
    public event Action<Ball> Killed;
    public event Action<Ball> FinalyDestroyed;

    public float Speed { get; private set; }
    public int Prize { get; private set; }
    public int Damage { get; private set; }
    public Color Color { get; private set; }
    public Vector3 Position { get; private set; }
    public Vector3 Scale { get; private set; }

    public bool IsActive { get; private set; }

    public bool IsPaused => !IsPlaying;

    public bool IsPlaying { get; private set; }

    public void Tick(float deltaTime)
    {
        if (IsPlaying)
        {
            Speed += _acceleration * Time.timeScale;
            Position -= new Vector3(0, Speed * Time.deltaTime);
            PositionChanged?.Invoke(Position);
        }
    }

    public void FinalyDestroy()
    {
        FinalyDestroyed?.Invoke(this);
    }

    public void Kill()
    {
        Killed?.Invoke(this);
    }

    public void Activate(BallSettings settings)
    {
        Position = settings.Position;
        Scale = settings.Scale;

        Speed = settings.Speed;
        Prize = settings.PrizePoints;
        Damage = settings.PlayerDamagePoints;

        Color = settings.Color;

        _acceleration = settings.Acceleration;

        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Play()
    {
        if (IsActive)
        {
            IsPlaying = true;
        }
    }

    public void Pause()
    {
        if (IsActive && IsPlaying)
        {
            IsPlaying = false;
        }
    }

    public void Restart()
    {
        Play();
    }

    public void Stop()
    {
        Pause();
    }

    public void Select()
    {
        Clicked?.Invoke(this);
    }
}
