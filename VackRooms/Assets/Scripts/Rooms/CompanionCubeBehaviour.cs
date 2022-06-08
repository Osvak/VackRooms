using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionCubeBehaviour : MonoBehaviour
{
    public bool touched;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Controller" && !touched)
        {
            touched = true;
        }
    }
}
