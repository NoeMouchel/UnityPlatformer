using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//  This class is used by the enemy and traps to deal damage to the player (or ohter entity)
public class ActionDealer : MonoBehaviour
{
    public int damage = 1;
    public int knockBackStrength = 1;

    //  Deal Damage if the target is a player
    public void DealDamageTo(GameObject target)
    {
        if(target.TryGetComponent<HealthPoint>(out HealthPoint m_targetLife))
        {
            m_targetLife.TakeDamage(damage);
        }
    }


    public void DealKnockBackTo(Rigidbody other, Vector3 direction)
    {
        other.velocity = other.transform.right * other.velocity.x + direction * knockBackStrength;
    }
}
