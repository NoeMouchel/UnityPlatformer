using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(HealthPoint))]
[RequireComponent(typeof(PlayerMove))]
[RequireComponent(typeof(PlayerJump))]
public class PlayerController : MonoBehaviour
{
    //  Private variables
    private Rigidbody   m_rb;
    private EntityState m_state_manager;
    private PlayerJump  m_jump;
    private PlayerMove  m_move;
    
    [HideInInspector]
    public HealthPoint m_hp;

    [HideInInspector]
    public TryPoint m_tp;

    public float x_movement;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
        m_state_manager = GetComponent<EntityState>();
        m_move = GetComponent<PlayerMove>();
        m_jump = GetComponent<PlayerJump>();

        m_hp = GetComponent<HealthPoint>();
    }


    // Update is called once per frame
    void Update()
    {

        if (m_hp.IsMin())
        {
            GameEvents.PlayerDestroy();
        }

        if (m_rb.velocity.x == 0f)
        {
            m_state_manager.IsIddle();
        }
    }

    //  Simple Jump
    public void JumpPressed()
    {
        m_jump.StartJump();
    }

    //  Long Jump when holding down Space key
    public void JumpHolded()
    {
        m_jump.Jumping();
    }
   

    public void MoveButtonPressed(float value)
    {
        m_move.m_x_axis_direction = value;
        m_state_manager.IsMoving();
    }
 
}
