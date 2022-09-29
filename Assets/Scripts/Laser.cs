using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public ActionDealer m_action_dealer;

    public LineRenderer m_laser;

    public ParticleSystem m_impact_effect;

    public bool m_camera_shake;

    private int m_layerMask;

    private void Awake()
    {
        
    }

    public void NotShoot()
    {
        if (m_laser.enabled)
        {
            m_laser.enabled = false;
        }

        if(m_impact_effect.isPlaying)
        {
            m_impact_effect.Stop();
        }
    }

    public void Shoot(Vector3 dir, float max_reach)
    {
        if (!m_laser.enabled)
        {
            m_laser.enabled = true;
        }

        m_laser.SetPosition(0, transform.position);

        //  Shoot where it's looking
        if (Physics.Raycast(transform.position, dir, out RaycastHit hit, max_reach,))
        {
            m_laser.SetPosition(1, hit.point);

            if (m_impact_effect.isPlaying == false)
            {
                m_impact_effect.Play();
            }

            m_impact_effect.transform.position = hit.point;
            m_impact_effect.transform.forward = -dir;

            if(m_camera_shake)
            {
                //  Camera Shake will occur
                GameEvents.LaserHit();
            }

            m_action_dealer.DealDamageTo(hit.collider.gameObject);
        }
        else
        {
            m_laser.SetPosition(1, transform.position + dir * max_reach);

            if (m_impact_effect.isPlaying)
            {
                m_impact_effect.Stop();
            }
        }
    }
}
