using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class AudioManager : MonoBehaviour
{
    public Vector3 Info;
    public Events[] sounds;
    public static AudioManager instance;

    void Awake()
    {
        if(instance == null)    instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Events s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    void Start()
    {
        Play("Knocking");
    }
    public void Play(string name)
    {
        Events s = Array.Find(sounds,sounds => sounds.name == name);
        if(s == null)   return;
        if(!s.outManager)   s.source.Play();
        else
        {
            if(s.prebab != null)    Instantiate(s.prebab,s.prebab.transform.position,s.prebab.transform.rotation);
        }
    }
}
