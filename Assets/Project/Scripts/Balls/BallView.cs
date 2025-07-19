using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Renderer))]
public class BallView : MonoBehaviour, IPointerDownHandler, IActivatable
{
    private Ball _ball;
    private Renderer _renderer;

    public bool IsActive => gameObject.activeInHierarchy;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void Init(Ball ball)
    {
        _ball = ball;
        SetColor(ball.Color);
        SetScale(ball.Scale);
        _ball.PositionChanged += OnPositionChanged;
    }

    private void OnPositionChanged(Vector3 obj)
    {
        transform.position = _ball.Position;
    }

    private void SetColor(Color color)
    {
        _renderer.material.SetColor("_Color", color);
    }

    private void SetScale(Vector3 size)
    {
        transform.localScale = size;
    }

    public void Activate()
    {
        transform.position = _ball.Position;
        transform.localScale = _ball.Scale;
        SetColor(_ball.Color);
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        transform.localScale = Vector3.one;
        gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _ball.Select();
    }
}
