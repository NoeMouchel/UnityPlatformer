using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBridge : MonoBehaviour
{
    private void Awake()
    {
        GameEvents.OnBossKilled += Active;
    }

    private void OnDisable()
    {
        GameEvents.OnBossKilled -= Active;
    }

    public void Active()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
}
