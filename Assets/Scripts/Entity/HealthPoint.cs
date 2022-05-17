using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoint : PointSystem
{
    public bool m_invulnerability_timer;
    public bool m_start_with_full_life;

    public bool m_is_player;

    public TimerBool m_is_vulnerable;

    private new void Start()
    {
        base.Start();
        if(m_start_with_full_life || m_point > m_max)
        {
            m_point = m_max;
        }
    }

    private void Update()
    {
        if (m_invulnerability_timer)
        {
            m_is_vulnerable.Update();
        }

    }


    //  Take Damage
    public void TakeDamage(int damage)
    {
        //  Can receive damage? (only if invulnerability timer is enabled)
        if(m_invulnerability_timer)
        {
            if (m_invulnerability_timer && m_is_vulnerable.Check()) return;

            m_is_vulnerable.Toggle();
        }

        Decrease(damage);

        if (m_is_player)
        {
            GameEvents.PlayerHit();
        }
    }
}
