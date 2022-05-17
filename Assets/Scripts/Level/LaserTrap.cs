using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    public Laser m_laser;

    public float m_shoot_timer = 5f;
    public float m_shoot_duration = 2f;
    public float m_distance = 25f;

    private float time_stock_1 = 0f;
    private float time_stock_2 = 0f;

    public bool m_can_shoot = false;


    private void Update()
    {
        if(m_can_shoot)
        {
            m_laser.Shoot(-transform.forward, m_distance);

            ShootDuration();
        }
        else
        {
            m_laser.NotShoot();

            ShootTimer();
        }
    }

    private void ShootTimer()
    {
        time_stock_1 += Time.deltaTime;

        if (time_stock_1 > m_shoot_timer)
        {
            time_stock_1 = 0f;
            m_can_shoot = true;
        }
    }

    private void ShootDuration()
    {
        time_stock_2 += Time.deltaTime;

        if (time_stock_2 > m_shoot_duration)
        {
            time_stock_2 = 0f;
            m_can_shoot = false;
        }
    }
}
