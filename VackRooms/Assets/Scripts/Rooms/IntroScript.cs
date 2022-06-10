using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    public GameObject player;
    public List<AudioMixerGroup> mixers;

    // Start is called before the first frame update
    void Start()
    {
        mixers[0].audioMixer.SetFloat("Volume F", -80.0f);
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
            mixers[0].audioMixer.SetFloat("Volume F", 0.0f);
            mixers[1].audioMixer.SetFloat("Volume I", -40.0f);
        }  
    }
}
