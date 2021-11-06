using UnityEngine;

public interface IPoolable
{
    void Activate(BalloonSettings settings);
    void Deactivate();
}

public interface IBalloonCreator
{
    Balloon Create(int number);
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