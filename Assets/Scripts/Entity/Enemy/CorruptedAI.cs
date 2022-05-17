using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CorruptedAI : MonoBehaviour
{
    public Transform    m_body;
    public Transform    m_eye;
    public ActionDealer m_action_dealer;

    public Laser   m_laser_cannon;

    public Transform    m_target;
    public Vector3      m_hit_zone;

    public float        m_shoot_timer = 5f;
    public float        m_shoot_duration = 2f;
    public float        m_targetting_speed = .1f;

    public float        m_max_distance = 5000f;

    public  GameObject m_explosion_animation;
    private HealthPoint  m_hp;

    private float time_stock_1 = 0f;
    private float time_stock_2 = 0f;

    private bool  m_can_shoot = false;


    private void Awake()
    {
        m_hp = GetComponent<HealthPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_hp.IsMin())
        {
            m_explosion_animation.transform.SetParent(null);
            m_explosion_animation.SetActive(true);
            GameEvents.BossKilled();
            Destroy(gameObject, 3f);
        }

        if (!m_can_shoot)
        {
            m_laser_cannon.NotShoot();
        }

        if (m_target != null)
        {
            LookAtTarget();

            if(!m_can_shoot)
            { 
                m_eye.localScale = Vector3.Lerp(m_eye.localScale, Vector3.one, .1f);
                ShootTimer();
            }
            else
            {
                m_eye.localScale = Vector3.Lerp(m_eye.localScale, new Vector3(1f,1f,.25f), .1f);
                m_laser_cannon.Shoot(m_hit_zone - m_laser_cannon.transform.position, m_max_distance);

                ShootDuration();
            }
        }
    }

    private void ShootTimer()
    {
        time_stock_1 += Time.deltaTime;

        if(time_stock_1 > m_shoot_timer)
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

    private void LookAtTarget()
    {
        m_hit_zone = Vector3.Lerp(m_hit_zone, m_target.position, m_targetting_speed);

        m_body.right = Vector3.Lerp(m_body.right, Vector3.Normalize(m_hit_zone - m_body.position), m_targetting_speed);
        
        Vector3 eye_right = Vector3.Normalize(m_hit_zone - m_body.position);

        //  so the pupil do not leave the eye
        if (Vector3.Dot(eye_right, m_body.right) > .98f)
        {
            m_eye.right = eye_right;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_target = null;
        }
    }
}
