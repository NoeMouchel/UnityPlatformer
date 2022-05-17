using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointAnimation : MonoBehaviour
{
    private Animator m_animator;
    public bool     m_player_near;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
            m_player_near = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            m_player_near = false;
    }



    // Update is called once per frame
    void Update()
    {
        m_animator.SetBool("PlayerNear", m_player_near);
    }
}
