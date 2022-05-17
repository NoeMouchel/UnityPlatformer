using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameOver : MonoBehaviour
{
    public GameObject m_pause;
    public GameObject m_gameOver;

    private void OnEnable()
    {
        GameEvents.OnGameOver += DisplayGameOverScreen;
    }

    private void OnDisable()
    {
        GameEvents.OnGameOver -= DisplayGameOverScreen;
    }

    private void DisplayGameOverScreen()
    {
        GameEvents.Pause();
        m_pause.SetActive(false);
        m_gameOver.SetActive(true);
    }

}
