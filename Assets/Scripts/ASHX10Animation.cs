using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASHX10Animation : MonoBehaviour
{
    private Rigidbody rb;
    public Transform mesh_wheel;
    
    public float turnAroundSpeed = 0.1f;
    
    private Vector3 oldPos;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        oldPos = rb.transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        //  When Y has velocity, we need to know which direction the object is taking
        float direction = Vector3.Normalize(transform.position - oldPos).x;
        oldPos = rb.transform.position;
    
        mesh_wheel.Rotate(0f, 0f, (-rb.velocity.x + direction * rb.velocity.y) / Mathf.PI);
    }    
}
