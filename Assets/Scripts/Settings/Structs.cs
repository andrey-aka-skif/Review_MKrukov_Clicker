using UnityEngine;

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

public struct SpawnerParams
{
    public float MinTimeOut { get; set; }
    public float MaxTimeOut { get; set; }
    public float CreationTimeDecrease { get; set; }
    public float Acceleration { get; set; }
}