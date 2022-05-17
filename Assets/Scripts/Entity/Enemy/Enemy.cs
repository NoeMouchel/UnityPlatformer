using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActionDealer))]
[RequireComponent(typeof(EntityState))]
public class Enemy : MonoBehaviour
{
    public int   life  = 1;
    public float speed = 1f;
    public float rotationSpeed = .7f;

    public EntityState   m_state_manager;
    public ActionDealer  m_action_dealer;

    public Loot[] m_lootable;
    public float  m_loot_chance;

    protected Rigidbody rb;
    protected float direction = 1f;
    protected bool stopped = false;

    private float rotationTimer = 0f;
    private int m_layer_mask;

    protected bool m_is_ground;
    protected bool m_is_wall;

    protected void Awake()
    {
        //  Layer to ignore when RayCasting
        m_layer_mask = ~(1 << LayerMask.NameToLayer("Player") | 1 << LayerMask.NameToLayer("Enemy") | 1 << LayerMask.NameToLayer("Platform"));
        rb = GetComponent<Rigidbody>();
    }

    protected void Update()
    {
        CheckLife();

        if (stopped)
        {
            StopTimer();
        }
    }

    protected void CheckObstacle()
    {
        m_is_ground = RayCheck.IsGroundInDir(transform, transform.right * direction, m_layer_mask);
        m_is_wall = RayCheck.IsWallInDir(transform, transform.right * direction, m_layer_mask);
    }

    protected void LinearDisplacement()
    {
        CheckObstacle();

        if (stopped == false && (m_is_wall || !m_is_ground))
        {
            //m_state_manager.IsRotating();
            stopped = true;
            direction = (-1f) * direction;
        }
        else if (stopped == false)
        {
            m_state_manager.IsMoving();
            rb.velocity = rb.transform.right * direction * speed + rb.transform.up * rb.velocity.y;
        }
    }

    protected void StopTimer()
    {
        rotationTimer += Time.deltaTime;

        if (rotationTimer > .5f)
        {
            rotationTimer = 0f;
            stopped = false;
        }
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
    }

    private void CheckLife()
    {
        if (life <= 0)
        {
            if (m_lootable.Length > 0)
            {
                Loot to_loot = m_lootable[Random.Range(0, m_lootable.Length)];
                if (Random.Range(0f, 1f) <= m_loot_chance * to_loot.m_loot_chance)
                {
                    Instantiate(to_loot,transform.position + Vector3.up * .5f, Quaternion.identity,null);
                }
            }
            //  For now, but should put animation etc...
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 enemy_other = collision.transform.position - transform.position;
        if (collision.gameObject.CompareTag("Player"))
        {
            //  KnockBack
            m_action_dealer.DealKnockBackTo(collision.rigidbody, enemy_other.normalized);

            if (Mathf.Abs(enemy_other.x) < transform.lossyScale.x && enemy_other.y > 0)
            {
                TakeDamage(1);
                return;
            }

            m_action_dealer.DealDamageTo(collision.gameObject);
        }
    }
}
