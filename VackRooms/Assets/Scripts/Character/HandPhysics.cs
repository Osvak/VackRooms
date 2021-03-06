using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPhysics : MonoBehaviour
{
    public Transform target;
    public Rigidbody rb;
    private Collider[] handColliders;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        handColliders = GetComponentsInChildren<Collider>();
    }

    public void EnableHandCollider()
    {
        foreach(var item in handColliders)
        {
            item.enabled = true;
        }
    }

    public void EnableHandColliderDelay(float delay)
    {
        Invoke("EnableHandCollider", delay);
    }

    public void DisableHandCollider()
    {
        foreach (var item in handColliders)
        {
            item.enabled = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = (target.position-transform.position)/Time.fixedDeltaTime;

        Quaternion rotDiff = target.rotation * Quaternion.Inverse(transform.rotation);
        rotDiff.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);
        Vector3 rotDiffInDegree = angleInDegree * rotationAxis;

        rb.angularVelocity = (rotDiffInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);
    }
}
