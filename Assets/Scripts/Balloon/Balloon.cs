using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Renderer))]
public class Balloon : MonoBehaviour, IPointerDownHandler, IPoolable
{
    private bool _isAlive;
    private float _acceleration;
    private Renderer _renderer;

    public BalloonClickedEvent Clicked;
    public BalloonTouchBorderEvent BorderTouched;

    [HideInInspector] public BalloonDestroyedEvent Destroyed;

    public float Speed { get; private set; }
    public int Prize { get; private set; }
    public int Damage { get; private set; }
    public Color Color { get; private set; }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        Clicked ??= new BalloonClickedEvent();
        BorderTouched ??= new BalloonTouchBorderEvent();
        Destroyed ??= new BalloonDestroyedEvent();
    }

    private void OnDisable()
    {
        Clicked.RemoveAllListeners();
        BorderTouched.RemoveAllListeners();
        Destroyed.RemoveAllListeners();
    }

    private void Update()
    {
        if (_isAlive)
        {
            Speed += _acceleration * Time.timeScale;
            transform.position -= new Vector3(0, Speed * Time.deltaTime);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_isAlive)
        {
            _isAlive = false;
            Clicked?.Invoke(this);
        }
    }

    public void OnReadyToDestroy()
    {
        Destroyed?.Invoke(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isAlive && other.TryGetComponent(out ILimit _))
        {
            _isAlive = false;
            BorderTouched?.Invoke(this);
        }
    }

    public void Activate(BalloonSettings settings)
    {
        gameObject.SetActive(true);

        _isAlive = true;

        transform.position = settings.Position;
        transform.localScale = settings.Scale;

        Speed = settings.Speed;
        Prize = settings.PrizePoints;
        Damage = settings.PlayerDamagePoints;

        Color = settings.Color;
        SetColor(settings.Color);

        _acceleration = settings.Acceleration;
    }

    public void Deactivate()
    {
        _isAlive = false;

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
        gameObject.SetActive(false);
    }

    private void SetColor(Color color)
    {
        _renderer.material.SetColor("_Color", color);
    }
}