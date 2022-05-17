using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASHX20Animations : MonoBehaviour
{
    private Rigidbody   rb;
    public  Animator    m_animController;
    public  EntityState m_state_manager;
    
    public  Transform mesh_wheel;
    public  Transform mesh_quadran;
    public  Transform mesh_body;

    public float turnAroundSpeed = 0.1f;
    public float direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //  When Y has velocity, we need to know which direction the object is taking
        float direction = rb.velocity.x;

        if (rb.velocity.x != 0f)
            direction = rb.velocity.x / Mathf.Abs(rb.velocity.x);

        mesh_wheel.Rotate(0f, 0f, (-rb.velocity.x + direction * rb.velocity.y) / Mathf.PI);
        Rotate(rb.velocity.x);

        if (m_state_manager == null) return;

        switch (m_state_manager.m_state)
        {
            case EntityStates.Iddle:
                PlayIddle();
                break;
            case EntityStates.Moving:
                PlayMoving();
                break;
            case EntityStates.Jumping: 
                break;
            case EntityStates.Landing: 
                break;
            default:
                PlayIddle();
                break;
        }
    }

    public void Rotate(float direction)
    {
            Quaternion rot = mesh_quadran.rotation;

            if (direction == 0f) return; 
            if (direction > 0f)
            {
                mesh_quadran.rotation = Quaternion.Lerp(rot, Quaternion.Euler(rot.eulerAngles.x, rot.eulerAngles.y, 5f), turnAroundSpeed);
            }
            else 
            {
                mesh_quadran.rotation = Quaternion.Lerp(rot, Quaternion.Euler(rot.eulerAngles.x, rot.eulerAngles.y, 175f), turnAroundSpeed);
            }
    }

    public void PlayIddle()
    {
        m_animController.SetBool("Iddle", true);
        m_animController.SetBool("Moving", false);
        //m_animController.SetBool("Jumping", true);
    }

    public void PlayMoving()
    {
        m_animController.SetBool("Iddle", false);
        m_animController.SetBool("Moving", true);
        //m_animController.SetBool("Jumping", true);
    }

    public void PlayJumping()
    {
        m_animController.SetBool("Iddle", false);
        m_animController.SetBool("Moving", false);
        //m_animController.SetBool("Jumping", true);
    }
}
