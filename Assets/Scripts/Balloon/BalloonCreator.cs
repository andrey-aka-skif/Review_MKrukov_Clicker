using UnityEngine;

public class BalloonCreator : IBalloonCreator
{
    private readonly Balloon _prefab;
    private readonly Transform _root;

    public BalloonCreator(Balloon prefab, Transform root)
    {
        _prefab = prefab;
        _root = root;
    }

    public Balloon Create()
    {
        Balloon balloon = Object.Instantiate(_prefab, _root);
        return balloon;
    }
}