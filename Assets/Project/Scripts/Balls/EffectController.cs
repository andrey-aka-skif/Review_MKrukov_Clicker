using System;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    private Ball _ball;
    private readonly List<IEffect> _effects = new();

    public void Init(Ball ball)
    {
        _ball = ball;
    }

    private void OnEnable()
    {
        _ball.Clicked += OnBallDestroy;
        _ball.Killed += OnBallDestroy;
    }

    private void OnDisable()
    {
        _ball.Clicked -= OnBallDestroy;
        _ball.Killed -= OnBallDestroy;

        foreach (var effect in _effects)
        {
            effect.Completed -= OnEffectCompleted;
        }
    }

    public void RegistrateEffect(IEffect effect)
    {
        if (effect == null)
            throw new NullReferenceException("Попытка зарегистрировать пустой эффект");

        _effects.Add(effect);
        effect.Completed += OnEffectCompleted;
    }

    private void OnBallDestroy(Ball ball)
    {
        foreach (var effect in _effects)
        {
            effect.Run();
        }
    }

    private void OnEffectCompleted(IEffect effect)
    {
        if (effect == null) return;

        effect.Completed -= OnEffectCompleted;

        _effects.Remove(effect);

        if (_effects.Count == 0)
        {
            _ball.FinalyDestroy();
        }
    }
}
