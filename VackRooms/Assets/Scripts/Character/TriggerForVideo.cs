using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForVideo : MonoBehaviour
{
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "TriggerForVideo")
        {
            transform.position = startPos;
        }
    }
}
