using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject m_enemyOriginal;
    private GameObject m_enemyInstance;

    private void OnEnable()
    {
        GameEvents.OnPlayerSpawn += SpawnEnemy;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerSpawn -= SpawnEnemy;
    }

    private void SpawnEnemy()
    {
        if (m_enemyInstance != null) Destroy(m_enemyInstance);
        m_enemyInstance = Instantiate(m_enemyOriginal, transform.position, Quaternion.identity);
    }
}
