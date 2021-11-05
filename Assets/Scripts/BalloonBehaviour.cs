using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Balloon))]
public class BalloonBehaviour : MonoBehaviour
{
    [SerializeField] private float _boomScaleMultiplier = 2;
    [SerializeField] private float _boomGrowSpeed = 2;

    [SerializeField] private ParticleController _particles;

    public BallonDestroyedEvent Destroyed { get; private set; }

    private Balloon _balloon;

    private void OnEnable()
    {
        Destroyed ??= new BallonDestroyedEvent();
        _balloon?.Clicked.AddListener(OnReadyToDestroy);
        _balloon?.BorderTouched.AddListener(OnReadyToDestroy);
    }

    private void OnDisable()
    {
        Destroyed.RemoveAllListeners();
    }

    public void Init(Balloon balloon)
    {
        _balloon = balloon != null ? balloon : throw new System.ArgumentNullException();

        _balloon.Clicked.AddListener(OnReadyToDestroy);
        _balloon.BorderTouched.AddListener(OnReadyToDestroy);

        gameObject.SetActive(true);

        _particles.Init(Destroy);
    }

    public void SetColor(Color color)
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_Color", color);

        _particles.SetColor(color);
    }

    private void OnReadyToDestroy(Balloon balloon)
    {
        StartCoroutine(Boom());
    }

    private void Destroy()
    {
        Destroyed?.Invoke(_balloon);
    }

    private IEnumerator Boom()
    {
        float targetScale = transform.localScale.x * _boomScaleMultiplier;

        while (transform.localScale.x <= targetScale)
        {
            transform.localScale += _boomGrowSpeed * Time.deltaTime * new Vector3(1, 1, 1);
            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.zero;

        _particles.Play();

        //Destroy();
    }
}