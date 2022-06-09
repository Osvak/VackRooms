using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    public GameObject player;
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
      if(other.transform.tag == "Controller")
        {
            Debug.Log("KFADKLSHFADSHKLFADSHLAHSFKLADHSKLFHAKLSFHADKLSHAFSKLF");
            player.transform.position = new Vector3(23, 0, 0.85f);
            GameObject.Find("Intro").GetComponent<AudioSource>().enabled = false;
        }  
    }
}
