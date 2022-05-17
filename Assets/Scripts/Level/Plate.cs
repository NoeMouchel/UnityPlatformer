using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public bool m_activated;
    public GameObject m_pad;
    public  Material  m_activated_mat;
    private Material  m_default_mat;

    private void Start()
    {
        m_default_mat = m_pad.GetComponent<Renderer>().material;
    }

    private void FixedUpdate()
    {
        m_activated = false;
    }

    private void OnTriggerStay(Collider other)
    {
        m_activated = true;
        m_pad.GetComponent<Renderer>().material = m_activated_mat;
    }

    private void OnTriggerExit(Collider other)
    {
        m_activated = false;
        m_pad.GetComponent<Renderer>().material = m_default_mat;
    }
}
