using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class BallonDestroyedEvent : UnityEvent<Balloon> { }
[Serializable] public class BallonClickedEvent : UnityEvent<Balloon> { }
[Serializable] public class BallonTouchBorderEvent : UnityEvent<Balloon> { }

[Serializable] public class AddScoreEvent : UnityEvent<int> { }
[Serializable] public class AddDamageEvent : UnityEvent<int> { }

[Serializable] public class ChangeHealthEvent : UnityEvent<int> { }
[Serializable] public class ChangeScoreEvent : UnityEvent<int> { }
[Serializable] public class ChangeBestScoreEvent : UnityEvent<int> { }

public interface IObjectAsParameter { }

public struct BalloonSettings : IObjectAsParameter
{
    public Vector3 Position { get; set; }
    public Vector3 Scale { get; set; }
    public Color Color { get; set; }
    public float Speed { get; set; }
    public float Acceleration { get; set; }
    public int PrizePoints { get; set; }
    public int PlayerDamagePoints { get; set; }
}

public interface IPoolable
{
    void SetState(IObjectAsParameter parameter);
    void ResetState();
}

public interface IPoolObjectCreator<T>
{
    T Create();
}

public interface IZoned
{
    Vector3 Center { get; }
    Vector3 Size { get; }
}

public interface ISpawnZone : IZoned
{
    Vector3 GetRndPosition();
}

public interface ILimit { }