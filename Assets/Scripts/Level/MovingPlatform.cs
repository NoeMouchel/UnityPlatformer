using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject   m_start;
    public GameObject   m_end;

    public float    m_speed = .1f;
    public float    m_pause_time = 1f;

    public int      m_direction_value = 1;
    private Vector3 m_direction;

    private Vector3     m_target;

    private Animator     m_animator;
    public TimerBool       m_moving;

    public GameObject m_player_sit;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        m_direction = Vector3.Normalize(m_end.transform.position - m_start.transform.position);
        m_moving = new TimerBool
        {
            m_start_value = false,
            m_duration = m_pause_time
        };
    }

    private void Update()
    {
        m_moving.Update();

        
        if (m_direction_value < 0f)
        {
            m_target = m_start.transform.position;
        }
        else
        {
            m_target = m_end.transform.position;
        }

        //  Is moving
        if (m_moving.Check())
        {
            m_animator.SetFloat("Speed", (float)m_direction_value * m_speed * 50f);
            transform.position = Vector3.MoveTowards(transform.position, m_target, m_speed);
            if(transform.position == m_target)
            {
                StopMoving();
            }
        }
        else
        {
            m_animator.SetFloat("Speed", 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == false) return;

        float Y_dir = Vector3.Dot(other.transform.position - transform.position, -transform.up);
        
        //  If a object is detected under the platform, change direction
        if(Y_dir>0f)
        {
            if(Vector3.Dot(m_direction * m_direction_value,-transform.up) > .5f) 
            {
                //  Inverse direction
                m_direction_value = -m_direction_value;
            }

            return;
        }

        //  Else if it's ON, change parent transform of the object
        other.transform.parent = m_player_sit.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") == false) return;

        //  If objec exit the trigger, unparent him
        other.transform.parent = null;
    }

    private void StopMoving()
    {
        //  Stop movements
        m_moving.Reset();

        //  Inverse direction
        m_direction_value = -m_direction_value;
    }
}
