using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColorChange : MonoBehaviour
{
    public Light sunLight;
    public Transform rotPos;
    public Space space;
    public float speed;
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //sunLight.transform.Rotate(new Vector3(0,1,0), space);
//        sunLight.transform.RotateAround(rotPos.position, new Vector3(0, 1, 0), Time.deltaTime);
    }
}
