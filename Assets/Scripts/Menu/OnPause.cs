using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPause : MonoBehaviour
{
    public GameObject m_pauseMenu;

    private void OnEnable()
    {
        GameEvents.OnPause  += Pause;
        GameEvents.OnResume += Resume;
    }

    private void OnDisable()
    {
        GameEvents.OnPause  -= Pause;
        GameEvents.OnResume -= Resume;
    }

    public void Pause()
    {
        DisplayPauseMenu();
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        HidePauseMenu();
        Time.timeScale = 1f;
    }

    private void DisplayPauseMenu()
    {
        m_pauseMenu.SetActive(true);
    }
    private void HidePauseMenu()
    {
        m_pauseMenu.SetActive(false);
    }
}
