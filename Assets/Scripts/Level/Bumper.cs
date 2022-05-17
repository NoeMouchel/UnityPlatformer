using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActionDealer))]
public class Bumper : MonoBehaviour
{
    public  float        m_strenght = 2f;
    private ActionDealer m_actionDealer;
    private Animator     m_animator;

    // Start is called before the first frame update
    void Start()
    {
        m_actionDealer = GetComponent<ActionDealer>();
        m_animator = GetComponentInParent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //  KnockBack
            m_actionDealer.DealKnockBackTo(collision.rigidbody, transform.up* m_strenght);
            m_animator.SetTrigger("OnUse");
        }
    }
}
