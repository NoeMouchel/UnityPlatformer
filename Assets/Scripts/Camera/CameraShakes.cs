using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakes : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.OnPlayerHit += ShakeOnPlayerHit;
        GameEvents.OnLaserHit  += ShakeOnLaserHit;
        GameEvents.OnBossKilled += ShakeOnBossKilled;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerHit -= ShakeOnPlayerHit;
        GameEvents.OnLaserHit  -= ShakeOnLaserHit;
        GameEvents.OnBossKilled -= ShakeOnBossKilled;
    }

    private void ShakeOnPlayerHit()
    {
        StartCoroutine(Shake(.15f, .2f));
    }

    private void ShakeOnLaserHit()
    {
        StartCoroutine(Shake(.1f, .2f));
    }

    private void ShakeOnBossKilled()
    {
        StartCoroutine(Shake(.1f, .2f));
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
