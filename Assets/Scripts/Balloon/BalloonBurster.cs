using System.Collections;
using UnityEngine;

public class BalloonBurster : MonoBehaviour
{
    [SerializeField] private float _boomScaleMultiplier = 2;
    [SerializeField] private float _boomGrowSpeed = 2;

    private Balloon _balloon;

    public BalloonBurstedEvent Bursted;

    private void OnEnable()
    {
        Bursted ??= new BalloonBurstedEvent();
    }

    private void OnDisable()
    {
        Bursted.RemoveAllListeners();
    }

    public void OnReadyToDestroy(Balloon balloon)
    {
        _balloon = balloon;
        StartCoroutine(Burst());
    }

    private IEnumerator Burst()
    {
        float targetScale = transform.localScale.x * _boomScaleMultiplier;

        while (transform.localScale.x <= targetScale)
        {
            transform.localScale += _boomGrowSpeed * Time.deltaTime * Vector3.one;
            yield return new WaitForEndOfFrame();
        }

        transform.localScale = Vector3.zero;

        Bursted?.Invoke(_balloon);
    }
}