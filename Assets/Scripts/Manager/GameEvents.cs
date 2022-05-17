using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static event Action OnPlayerDestroy;
    public static event Action OnPlayerSpawn;
    public static event Action OnPlayerHit;


    public static event Action OnLaserHit;
    public static event Action OnBossKilled;


    public static event Action OnPause;
    public static event Action OnResume;

    public static event Action OnFinish;
    public static event Action OnGameOver;

    public static void PlayerDestroy()
    {
        OnPlayerDestroy?.Invoke();
    }
    public static void PlayerSpawn()
    {
        OnPlayerSpawn?.Invoke();
    }
    public static void PlayerHit()
    {
        OnPlayerHit?.Invoke();
    }


    public static void LaserHit()
    {
        OnLaserHit?.Invoke();
    }
    public static void BossKilled()
    {
        OnBossKilled?.Invoke();
    }


    public static void Pause()
    {
        OnPause?.Invoke();
    }
    public static void Resume()
    {
        OnResume?.Invoke();
    }

    public static void Finish()
    {
        OnFinish?.Invoke();
    }

    public static void GameOver()
    {
        OnGameOver?.Invoke();
    }
}
