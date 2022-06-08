using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateBehaviour : MonoBehaviour
{
    public bool activated = false;

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
        //Pasan cosas de terminar juego
        if(other.transform.tag == "CompanionCube")
        {
            activated = true;
            Debug.Log("TE PASASTE EL GEIMU");
        }
    }
}
