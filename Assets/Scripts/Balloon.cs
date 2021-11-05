using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BalloonBehaviour))]
public class Balloon : MonoBehaviour, IPointerDownHandler, IPoolable
{
    private float _speed;
    private float _acceleration;

    private BalloonBehaviour _behaviour;

    private bool IsAlive { get; set; }

    public BallonClickedEvent Clicked { get; private set; }
    public BallonTouchBorderEvent BorderTouched { get; private set; }

    public int PrizePoints { get; private set; }
    public int DamageToPlayer { get; private set; }

    private void OnEnable()
    {
        Clicked ??= new BallonClickedEvent();
        BorderTouched ??= new BallonTouchBorderEvent();
    }

    private void OnDisable()
    {
        Clicked.RemoveAllListeners();
        BorderTouched.RemoveAllListeners();
    }

    private void Update()
    {
        if (IsAlive)
        {
            _speed += _acceleration;
            transform.position -= new Vector3(0, _speed * Time.deltaTime);
        }
    }

    public void Init()
    {
        _behaviour = GetComponent<BalloonBehaviour>();
        _behaviour.Init(this);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        IsAlive = false;
        Clicked?.Invoke(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ILimit _))
        {
            IsAlive = false;
            BorderTouched?.Invoke(this);
        }
    }

    public void SetState(IObjectAsParameter parameter)
    {
        gameObject.SetActive(true);

        IsAlive = true;

        BalloonSettings settings = (BalloonSettings)parameter;

        transform.position = settings.Position;
        transform.localScale = settings.Scale;

        _behaviour.SetColor(settings.Color);

        _speed = settings.Speed;
        _acceleration = settings.Acceleration;

        PrizePoints = settings.PrizePoints;
        DamageToPlayer = settings.PlayerDamagePoints;
    }

    public void ResetState()
    {
        IsAlive = false;

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        gameObject.SetActive(false);
    }
}