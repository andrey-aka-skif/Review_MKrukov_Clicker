using System;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleFuse : MonoBehaviour
{
    [SerializeField] private ParticleSystem _smoke;

    private Balloon _balloon;
    private ParticleSystem _particleSystem;
    private ParticleSystemRenderer _renderer;

    public BalloonExplodedEvent Exploded;

    private void Awake()
    {
        if (_smoke == null)
        {
            throw new NullReferenceException("Не указан объект smoke типа ParticleSystem");
        }

        _renderer = _smoke.GetComponent<ParticleSystemRenderer>();

        _particleSystem = GetComponent<ParticleSystem>();
    }

    public void Explode(Balloon balloon)
    {
        _balloon = balloon;
        SetSmokeColor(balloon.Color);
        _particleSystem.Play(true);
    }

    private void SetSmokeColor(Color color)
    {
        _renderer.material.SetColor("_Color", color);
    }

    private void OnParticleSystemStopped()
    {
        Exploded?.Invoke(_balloon);
    }
}