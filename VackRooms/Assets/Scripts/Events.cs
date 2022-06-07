using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Events
{
    public string name;
    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;
    [Range(.0f,3f)]
    public float pitch;

    public bool loop;
    public bool outManager;
    public GameObject prebab;

    [HideInInspector]
    public AudioSource source;
}

