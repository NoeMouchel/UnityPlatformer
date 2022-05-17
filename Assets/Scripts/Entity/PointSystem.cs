using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    public int      m_point;
    public int      m_max;

    protected int   m_min = 0;

    protected void Start()
    {
        m_min = Mathf.Min(m_min, m_max);

        if(m_min == m_max)
        {
            Debug.LogWarning(" m_min & m_max are equal, m_point has only one possible value.");
        }

        m_point = Mathf.Min(m_point, m_max);
        m_point = Mathf.Max(m_point, m_min);
    }


    //  Take Damage
    public void Decrement()
    {
        m_point = Mathf.Max(m_point - 1, 0);
    }

    public void Increment()
    {
        m_point = Mathf.Min(m_point + 1, m_max);
    }

    public void Decrease(in int points_to_remove)
    {
        m_point = Mathf.Max(m_point - points_to_remove, 0);
    }

    public void Increase(in int points_to_add)
    {
        m_point = Mathf.Min(m_point + points_to_add, m_max);
    }

    public bool IsMax()
    {
        return m_point >= m_max;
    }

    public bool IsMin()
    {
        return m_point <= m_min;
    }
}
