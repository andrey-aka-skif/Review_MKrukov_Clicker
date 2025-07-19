using UnityEngine;

/// <summary>
/// Создатель шара
/// </summary>
public class BalloonCreator : IBalloonCreator
{
    private readonly Balloon _prefab;
    private readonly Transform _root;

    public BalloonCreator(Balloon prefab, Transform root)
    {
        _prefab = prefab;
        _root = root;
    }

    public Balloon Create(int number)
    {
        var balloon = Object.Instantiate(_prefab, _root);
        balloon.transform.name = $"{typeof(Balloon)} ({number})";
        return balloon;
    }
}
