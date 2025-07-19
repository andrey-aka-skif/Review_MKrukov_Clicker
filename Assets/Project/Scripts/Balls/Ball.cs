using Assets.Project.Scripts.ScreenHelpers;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Шар
/// </summary>
[RequireComponent(typeof(Renderer))]
public class Ball : MonoBehaviour, IPointerDownHandler, IPoolable
{
    private bool _isAlive;
    private float _acceleration;
    private Renderer _renderer;

    /// <summary>
    /// Клик на шаре
    /// </summary>
    public BalloonClickedEvent Clicked;

    /// <summary>
    /// Шар коснулс¤ нижней границы
    /// </summary>
    public BalloonTouchBorderEvent BorderTouched;

    /// <summary>
    /// Шар на сцене окончательно уничтожен 
    /// </summary>
    [HideInInspector] 
    public BalloonDestroyedEvent Destroyed;

    /// <summary>
    /// Скорость падения
    /// </summary>
    public float Speed { get; private set; }

    /// <summary>
    /// Очки, получаемые за клик
    /// </summary>
    public int Prize { get; private set; }

    /// <summary>
    /// Штраф, получаемый при касании шаром нижней границы
    /// </summary>
    public int Damage { get; private set; }

    /// <summary>
    /// Цвет шара
    /// </summary>
    public Color Color { get; private set; }

    private void Awake() => _renderer = GetComponent<Renderer>();

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

    /// <summary>
    /// Шар готов к уничтожению и возврату в пул
    /// </summary>
    /// <remarks>
    /// При наличии компонента, добавляющего длительный эффект,
    /// компонент должен вызвать этот метод.
    /// Нужно для запуска события, сообщающего об окончательном уничтожении шара
    /// </remarks>
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

        transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        transform.localScale = Vector3.one;
        gameObject.SetActive(false);
    }

    private void SetColor(Color color)
    {
        _renderer.material.SetColor("_Color", color);
    }
}
