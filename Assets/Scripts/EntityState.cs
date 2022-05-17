using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EntityStates
{
    Iddle,
    Moving,
    Jumping,
    Landing,
    Rotating,
}


public class EntityState : MonoBehaviour
{
    public EntityStates m_state = EntityStates.Iddle;

    public void IsIddle()
    {
        m_state = EntityStates.Iddle;
    }

    public void IsMoving()
    {
        m_state = EntityStates.Moving;
    }

    public void IsJumping()
    {
        m_state = EntityStates.Jumping;
    }

    public void IsLanding()
    {
        m_state = EntityStates.Landing;
    }

    public void IsRotating()
    {
        m_state = EntityStates.Rotating;
    }
}
