using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2StayOnWall : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "P2")
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    public void OnCollisionExit(Collision other)
    {
        if(other.transform.tag == "P2")
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}
