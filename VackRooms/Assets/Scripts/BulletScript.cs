using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody rb;
    private bool startCount;
    private Vector3 colPos;
    private Quaternion colQuat;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startCount = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(startCount)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            rb.useGravity = false;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.useGravity = true;
        }
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag != "Bullet" && other.gameObject.name != "Gun")
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            startCount = true;
        }              
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Controller")
        {
            startCount = false;
        }
    }
    
}
