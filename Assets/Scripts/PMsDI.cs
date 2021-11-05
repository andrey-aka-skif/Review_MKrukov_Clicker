using System.Collections.Generic;
using System.Linq;
using UnityEngine;


// TODO Разделить на два класса
public class PMsDI : MonoBehaviour
{
    [SerializeField] Balloon _prefab;
    [SerializeField] Transform _spawnRoot;
    [SerializeField] float _minTimeOut = 1;
    [SerializeField] float _maxTimeOut = 5;
    [SerializeField] int _poolCapacity = 10;

    private void Awake()
    {
        ScreenInformer screenInformer = FindObjectOfType<ScreenInformer>();
        screenInformer.Init();

        ScreenTopSpawnZone spawnLimiter = FindObjectOfType<ScreenTopSpawnZone>();
        spawnLimiter.Init(screenInformer);

        BalloonCreator creator = new BalloonCreator(_prefab, _spawnRoot);

        BalloonPool pool = new BalloonPool(creator, _poolCapacity);

        Spawner spawner = FindObjectOfType<Spawner>();
        spawner.Init(pool, _minTimeOut, _maxTimeOut);

        DownScreenLimiter limiter = FindObjectOfType<DownScreenLimiter>();
        limiter.Init(screenInformer);
    }
}