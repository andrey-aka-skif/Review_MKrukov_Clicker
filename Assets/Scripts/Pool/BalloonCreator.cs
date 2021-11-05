using UnityEngine;

public class BalloonCreator : IPoolObjectCreator<Balloon>
{
    [SerializeField] private Balloon _prefab;
    [SerializeField] private Transform _root;

    public BalloonCreator(Balloon prefab, Transform root)
    {
        _prefab = prefab;
        _root = root;
    }

    public Balloon Create()
    {
        Balloon balloon = Object.Instantiate(_prefab, _root);
        balloon.Init();
        return balloon;
    }
}