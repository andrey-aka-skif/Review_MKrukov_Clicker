using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _target;

    private ParticleSystem _particleSystem;
    private UnityAction _callback;

    public void Init(UnityAction callback)
    {
        _callback = callback;
        _particleSystem = GetComponent<ParticleSystem>();

        if(_target == null)
        {
            throw new System.NullReferenceException();
        }
    }

    public void Play()
    {
        _particleSystem.Play(true);
    }

    public void SetColor(Color color)
    {
        Renderer renderer = _target.GetComponent<ParticleSystemRenderer>();
        renderer.material.SetColor("_Color", color);
    }

    private void OnParticleSystemStopped()
    {
        _callback?.Invoke();
    }
}