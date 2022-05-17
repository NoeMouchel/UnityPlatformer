using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TimerBool
{
    public float    m_duration = 1f;
    public bool     m_start_value = true;

    public bool    m_value;
    public float   m_elapsed = 0f;

    public void Update()
    {
        if (m_value == !m_start_value) return;

        m_elapsed += Time.deltaTime;
        if (m_elapsed > m_duration)
        {
            m_value = !m_start_value;
            m_elapsed = 0f;
        }
    }

    public void Toggle()
    {
        Reset();
    }
    public bool Check()
    {
        return m_value;
    }

    public void Reset()
    {
        m_value = m_start_value;
        m_elapsed = 0f;
    }
}
