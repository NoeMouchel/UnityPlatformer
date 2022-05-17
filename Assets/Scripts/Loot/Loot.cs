using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
  
    public float m_attraction_speed = .1f;
    public float m_loot_chance = 1f;
    
    private float m_start_distance;
    private bool resize;

    protected void Update()
    {
        float y_displacement = 0.0025f;

        Vector3 euler = transform.rotation.eulerAngles;

        transform.rotation = Quaternion.Euler(euler.x, euler.y + 1f, euler.z);

        transform.position += Vector3.up * Mathf.Cos(Time.time)* y_displacement;

        if(resize)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.one, .1f);
            if (transform.localScale == Vector3.one) resize = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        m_start_distance = Vector3.Distance(transform.position, other.transform.position);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.TryGetComponent<PlayerController>(out PlayerController player_controller))
        {
            if (CanBeAbsorbed(player_controller) == false) return;

            // Go toward the player
            transform.position = Vector3.Lerp(transform.position, other.transform.position, m_attraction_speed);

            float distance = Vector3.Distance(transform.position, other.transform.position);

            //  Scale down when getting close to the player
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * Mathf.Min((distance / m_start_distance),1f), .1f);

            //  When (Aproximately) reach the player, use it
            if (distance < .5f)
            {
                Use(player_controller);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        resize = true;
    }

    protected virtual bool CanBeAbsorbed(PlayerController pc)
    {
        return false;
    }

    protected virtual void Use(PlayerController pc)
    {

    }
}
