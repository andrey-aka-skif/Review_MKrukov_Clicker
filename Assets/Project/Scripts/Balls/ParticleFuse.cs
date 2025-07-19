using System;
using UnityEngine;

/// <summary>
/// Компонент, отвечающий за эффект взрыва с использованием частиц
/// </summary>
[RequireComponent(typeof(ParticleSystem))]
public class ParticleFuse : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _smoke;

    private Ball _balloon;
    private ParticleSystem _particleSystem;
    private ParticleSystemRenderer _renderer;


    /// <summary>
    /// Завершение эффекта взрыва
    /// </summary>
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

    public void Explode(Ball balloon)
    {
        _balloon = balloon;
        SetSmokeColor(balloon.Color);
        _particleSystem.Play(true);
    }

    private void SetSmokeColor(Color color) => _renderer.material.SetColor("_Color", color);

    private void OnParticleSystemStopped() => Exploded?.Invoke(_balloon);
}
