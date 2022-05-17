using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemy : Enemy
{
    public Transform target;

    private bool   has_target = false;
    private float old_direction;

    private new void Update()
    {
        if(has_target == false)
        {
            LinearDisplacement();
        }
        else
        {
            GetDirection();

            if(old_direction != direction)
            {
                stopped = true;
            }
            old_direction = direction;

            CheckObstacle();

            if (!stopped && ! m_is_wall && m_is_ground)
            {
                rb.velocity = rb.transform.right * direction * speed*2f + rb.transform.up * rb.velocity.y;
            }
            else
            {
                rb.velocity = rb.transform.right * 0f + rb.transform.up * rb.velocity.y;
            }
        }

        base.Update();
    }


    private void GetDirection()
    {
        if (target.position.x > transform.position.x)
        {
            direction = 1f;
        }
        else
        {
            direction = -1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Vector3.Dot(other.transform.position - transform.position, Vector3.right * direction) > 0f)
            {
                has_target = true;
                target = other.transform;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (has_target) return;
        if (other.CompareTag("Player"))
        {
            if (Vector3.Dot(other.transform.position - transform.position, Vector3.right * direction) > 0f)
            {
                has_target = true;
                target = other.transform;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            has_target = false;
        }
    }
}
