using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModifier : MonoBehaviour
{
    public float offset = 5f;
    public float height = 1.5f;
    public float speed = 0.05f;

    public CameraFollows m_camera;

    private float oldOffset;
    private float oldHeight;
    private float oldSpeed;

    private float defaultOffset;
    private float defaultHeight;
    private float defaultSpeed ;


    public bool resetDefault = false;
    private bool triggerEnabled = false;

    Transform m_transform;
    Vector3 oldDirection;

    private void OnEnable()
    {
        GameEvents.OnPlayerSpawn += SetDesactivated;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerSpawn -= SetDesactivated;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_transform = transform;
        defaultOffset = m_camera.m_offset;
        defaultHeight = m_camera.m_height;
        defaultSpeed  = m_camera.m_speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            oldDirection = new Vector3(other.transform.position.x -m_transform.position.x,0f,0f).normalized;
            PlayerEnterVolume();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //  Goes right
        Vector3 currentDirection = new Vector3(other.transform.position.x - m_transform.position.x, 0f, 0f).normalized;
        if (Vector3.Dot(currentDirection, oldDirection) > 0f)
        {
            SwitchVolume();
        }
    }

    private void PlayerEnterVolume()
    {
        if(!triggerEnabled)
            RegisterOldValues();
        SwitchVolume();
    }

    void SwitchVolume()
    {
        triggerEnabled = !triggerEnabled;
        if (triggerEnabled == false)
        {
            ResetOldValues();
        }
        else
        {
            if (resetDefault)
                ResetDefaultValues();
            else
                SetValues();
        }
        
    }


    //  Register Current values in Old values
    private void RegisterOldValues()
    {
        oldOffset = m_camera.m_offset;
        oldHeight = m_camera.m_height;
        oldSpeed = m_camera.m_speed;
    }


    //  SET VALUES
    private void SetValues()
    {
        m_camera.CameraModified(offset, height, speed);
    }

    //  RESET - OLD - DEFAULT

    private void ResetOldValues()
    {
        m_camera.CameraModified(oldOffset, oldHeight, oldSpeed);
    }


    void ResetDefaultValues()
    {
        m_camera.CameraModified(defaultOffset, defaultHeight, defaultSpeed);
    }

    void SetDesactivated()
    {
        triggerEnabled = false;
    }
}
