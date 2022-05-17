using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPoint : MonoBehaviour
{
    bool activated = false;
    public GameObject    playerSpawner;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if(activated == false)
        {
            playerSpawner.transform.position = transform.position;
            activated = true;

            if (playerSpawner.TryGetComponent<PlayerSpawn>(out PlayerSpawn ps))
            {
                ps.SaveCamera();
            }
        }
    }
}
