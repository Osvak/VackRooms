using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllersController : MonoBehaviour
{
    public GameObject leftController;
    public GameObject rightController;
    // Start is called before the first frame update
    void Start()
    {
        leftController.GetComponent<BoxCollider>().enabled = false;
        rightController.GetComponent<BoxCollider>().enabled = false;
        leftController.GetComponent<SphereCollider>().enabled = true;
        rightController.GetComponent<SphereCollider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Controller")
        {
            Debug.Log("Entered");
            leftController.GetComponent<BoxCollider>().enabled = true;
            rightController.GetComponent<BoxCollider>().enabled = true;
            leftController.GetComponent<SphereCollider>().enabled = false;
            rightController.GetComponent<SphereCollider>().enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Controller")
        {
            Debug.Log("Entered");
            leftController.GetComponent<BoxCollider>().enabled = false;
            rightController.GetComponent<BoxCollider>().enabled = false;
            leftController.GetComponent<SphereCollider>().enabled = true;
            rightController.GetComponent<SphereCollider>().enabled = true;
        }
    }
}
