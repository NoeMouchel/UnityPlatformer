using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
    //  Jump
    [Range(1f, 10f)]
    public float m_jump_velocity = 7.5f;
    public float m_fall_multiplier = 2.5f;
    public float m_low_jump_multiplier = 2f;


    public bool m_jumped;
    private bool m_is_jumping;
    private bool m_on_land;
    private Rigidbody m_rb;

    private LayerMask m_layer_mask;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_layer_mask = ~(1 << LayerMask.NameToLayer("Player") | 1 << LayerMask.NameToLayer("Trap") | 1 << LayerMask.NameToLayer("Bumper") | 1 << LayerMask.NameToLayer("Enemy"));
    }


    private void Update()
    {
        m_on_land = RayCheck.IsOnLand(transform, m_layer_mask);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (m_on_land) return;
        //  Increase gravity when velocity on y axis inverted
        if (m_rb.velocity.y < 0)
        {
            m_rb.velocity += Vector3.up * Physics.gravity.y * (m_fall_multiplier - 1) * Time.deltaTime;
            m_jumped = false;
        }
        //  Else if player stopped pressing jumping and the velocity is still going up we increase the falling speed
        else if (m_rb.velocity.y > 0 && !m_is_jumping)
        {
            m_rb.velocity += Vector3.up * Physics.gravity.y * (m_low_jump_multiplier - 1) * Time.deltaTime;
        }
        m_is_jumping = false;
    }






    //  Simple Jump
    public void StartJump()
    {
        if (m_on_land == false) return;

        m_jumped = true;
        m_rb.velocity += Vector3.up * m_jump_velocity;
    }

    //  Long Jump when holding down Space key
    public void Jumping()
    {
        if (m_on_land == true || m_jumped == false) return;
        m_is_jumping = true;
    }


}
