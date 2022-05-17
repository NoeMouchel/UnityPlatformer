using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTargetBoss : MonoBehaviour
{
    public Transform m_target;
    public Plate[]   m_plates;
    public Plate     m_plate_fire;
    public float     m_rotation_speed= .01f;

    private Vector3 m_direction;

    public Laser m_laser_cannon;
    public float m_max_distance;

    private void Start()
    {
        m_direction = Vector3.Normalize(m_target.position - transform.position);
    }
    private void Update()
    {
        if (CanTarget())
        {
            Target();
        }

        if(m_plate_fire.m_activated)
        {
            m_laser_cannon.Shoot(transform.forward, m_max_distance);
        }
        else
        {
            m_laser_cannon.NotShoot();
        }
    }

    private bool CanTarget()
    {
        foreach(Plate current_plate in m_plates)
        {
            if (current_plate.m_activated == false) return false;
        }
        return true;
    }

    private void Target()
    {
        transform.forward = Vector3.Lerp(transform.forward, m_direction, m_rotation_speed);
    }
}
