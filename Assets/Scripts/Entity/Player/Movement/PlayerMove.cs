using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    public float m_speed = 1f;
    public float m_max_speed = 5f;
    public float m_x_axis_drag = .1f;
    public float m_x_axis_direction = 1f;

    private Rigidbody m_rb;


    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DragOnXAxis();

        if (Mathf.Abs(m_rb.velocity.x) < 0.01f)
        {
            StopMovementOnXAxis();
        }

        if (RayCheck.IsWallInDir(transform, m_x_axis_direction * transform.right, (1 << LayerMask.NameToLayer("Structure"))))
        {
            StopMovementOnXAxis();
        }
        else if (m_x_axis_direction != 0f)
        {
            ApplyAcceleration();
        }
    }



    void StopMovementOnXAxis()
    {
        m_rb.velocity = transform.right * 0f + transform.up * m_rb.velocity.y;
    }

    private void ApplyAcceleration()
    {
        if (Mathf.Abs(m_rb.velocity.x) < m_max_speed)
        {
            m_rb.velocity += transform.right * (m_speed * m_x_axis_direction);
        }
    }

    private void DragOnXAxis()
    {
        //  Drag on X
        m_rb.velocity = Vector3.Lerp(m_rb.velocity, new Vector3(0, m_rb.velocity.y, m_rb.velocity.z), m_x_axis_drag);
    }
}
