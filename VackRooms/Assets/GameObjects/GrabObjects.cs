using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    public string layerName = "NoTRayCastObject";
    public int layerNumber = 13;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if(go.GetComponent<Rigidbody>() != null && go.GetComponent<XROffset>() != null)
            {
                go.gameObject.layer = layerNumber;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
