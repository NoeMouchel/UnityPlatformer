using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public GameObject m_crate;
    public GameObject m_instance;
    public float m_max_distance;

    private void Start()
    {
        Spawn();
    }
    // Update is called once per frame
    void Update()
    {
        if (m_instance == null)
        {
            Spawn();
        }
        if (Vector3.Distance(m_instance.transform.position, transform.position) > m_max_distance)
        {
            Destroy(m_instance);
        }
    }

    private void Spawn()
    {
        if (m_instance != null) Destroy(m_instance);
        
        m_instance = Instantiate(m_crate, transform.position, Quaternion.identity, null);
    }
}
