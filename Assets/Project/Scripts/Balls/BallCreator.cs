using UnityEngine;

/// <summary>
/// Создатель шара
/// </summary>
public class BallCreator : IBallCreator
{
    private readonly Ball _prefab;
    private readonly Transform _root;

    public BallCreator(Ball prefab, Transform root)
    {
        _prefab = prefab;
        _root = root;
    }

    public Ball Create(int number)
    {
        var balloon = Object.Instantiate(_prefab, _root);
        balloon.transform.name = $"{typeof(Ball)} ({number})";
        return balloon;
    }
}
