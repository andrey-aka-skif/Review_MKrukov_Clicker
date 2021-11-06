using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class BalloonDestroyedEvent : UnityEvent<Balloon> { }
[Serializable] public class BalloonClickedEvent : UnityEvent<Balloon> { }
[Serializable] public class BalloonTouchBorderEvent : UnityEvent<Balloon> { }

[Serializable] public class BalloonBurstedEvent : UnityEvent<Balloon> { }
[Serializable] public class BalloonExplodedEvent : UnityEvent<Balloon> { }

[Serializable] public class AddScoreEvent : UnityEvent<int> { }
[Serializable] public class AddDamageEvent : UnityEvent<int> { }

[Serializable] public class ChangeHealthEvent : UnityEvent<int> { }
[Serializable] public class ChangeScoreEvent : UnityEvent<int> { }
[Serializable] public class ChangeBestScoreEvent : UnityEvent<int> { }


public struct BalloonSettings
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
    void Activate(BalloonSettings settings);
    void Deactivate();
}

public interface IBalloonCreator
{
    Balloon Create();
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