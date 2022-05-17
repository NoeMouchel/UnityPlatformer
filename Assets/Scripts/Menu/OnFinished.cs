using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFinished : MonoBehaviour
{
    public GameObject m_pause;
    public GameObject m_finished;

    private void OnEnable()
    {
        GameEvents.OnFinish += DisplayFinishScreen;
    }

    private void OnDisable()
    {
        GameEvents.OnFinish -= DisplayFinishScreen;
    }

    private void DisplayFinishScreen()
    {
        GameEvents.Pause();
        m_pause.SetActive(false);
        m_finished.SetActive(true);
    }

}
