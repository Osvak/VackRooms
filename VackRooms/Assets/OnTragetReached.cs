using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTragetReached : MonoBehaviour
{
    public float trheshold;
    public Transform target;
    public UnityEvent OnReached;
    private bool wasReached=false;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if(distance < trheshold && !wasReached)
        {
            OnReached.Invoke();
            wasReached=true;
        }
        else if(distance >= trheshold)
        {
            wasReached=false;
        }
    }
}
