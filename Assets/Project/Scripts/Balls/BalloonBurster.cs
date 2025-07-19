using System.Collections;
using UnityEngine;

/// <summary>
/// Компонент отвечает за эффект взрыва шара
/// </summary>
public class BalloonBurster : MonoBehaviour
{
    [SerializeField] 
    private float _boomScaleMultiplier = 2;

    [SerializeField] 
    private float _boomGrowSpeed = 2;

    private Balloon _balloon;

    /// <summary>
    /// Эффект взрыва завершен
    /// </summary>
    public BalloonBurstedEvent Bursted;

    private void OnEnable() => Bursted ??= new BalloonBurstedEvent();

    private void OnDisable() => Bursted.RemoveAllListeners();

    /// <summary>
    /// Запустить анимацию взрыва
    /// </summary>
    /// <param name="balloon">Шар, который должен быть уничтожен после взрыва</param>
    public void OnReadyToDestroy(Balloon balloon)
    {
        _balloon = balloon;
        StartCoroutine(Burst());
    }

    private IEnumerator Burst()
    {
        var targetScale = transform.localScale.x * _boomScaleMultiplier;

        while (transform.localScale.x <= targetScale)
        {
            transform.localScale += _boomGrowSpeed * Time.deltaTime * Vector3.one;
            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.zero;

        Bursted?.Invoke(_balloon);
    }
}
