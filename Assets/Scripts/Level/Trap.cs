using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActionDealer))]
public class Trap : MonoBehaviour
{
    private ActionDealer m_actionDealer;
    // Start is called before the first frame update
    void Start()
    {
        m_actionDealer = GetComponent<ActionDealer>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        Vector3 enemy_other = collision.transform.position - transform.position;
        if (collision.gameObject.CompareTag("Player"))
        {
            m_actionDealer.DealDamageTo(collision.gameObject);

            //  KnockBack
            m_actionDealer.DealKnockBackTo(collision.rigidbody, enemy_other.normalized);
        }
    }
}
