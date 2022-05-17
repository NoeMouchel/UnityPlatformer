using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    public Transform m_target;
    Transform m_transform;

    [Range(-25f,25f)]
    public float m_offset = 5f;

    [Range(-5f, 10f)]
    public float m_height = 1.5f;

    [Range(0.001f, .1f)] 
    public float m_speed = .1f;

    private float m_new_offset = 5f;
    private float m_new_height = 1.5f;
    private float m_new_speed = .1f;

    private float m_transition_speed = 0.05f;
    //private bool  m_modified = false;

    public float  m_modifier_duration = 2f;
    private float m_modifier_timer = 0f;

    public TimerBool m_modified;


    // Start is called before the first frame update
    void Start()
    {
        m_transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        m_modified.Update();

        if (m_modified.Check())
        {
            m_offset = Mathf.Lerp(m_offset, m_new_offset, m_transition_speed);
            m_height = Mathf.Lerp(m_height, m_new_height, m_transition_speed);
            m_speed  = Mathf.Lerp(m_speed , m_new_speed , m_transition_speed);

            m_modifier_timer += Time.deltaTime;
            if(m_modifier_timer > m_modifier_duration)
            {
                m_modifier_timer = 0f;
            }
        }
        if (m_target != null)
        {
            m_transform.position = Vector3.Lerp(m_transform.position, m_target.position - (Vector3.forward * m_offset + Vector3.up * (-m_height)), m_speed);
            m_transform.forward = Vector3.Lerp(m_transform.forward, (m_target.position - m_transform.position).normalized, .01f);
        }
    }

    public void CameraModified(float offset, float height, float speed)
    {
        m_modified.Reset();

        m_new_offset = offset;
        m_new_height = height;
        m_new_speed  = speed;
    }

    public void CameraModifyNow(float offset, float height, float speed)
    {
        m_offset = offset;
        m_height = height;
        m_speed = speed;
    }


    public void LinkTo(GameObject target)
    {
        m_target = target.transform;
    }
}
