using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PuzzleNo3 : MonoBehaviour
{
    public GameObject presurePlate;
    public GameObject player;
    public List<AudioMixerGroup> mixers;


    [SerializeField]
    private PressurePlateBehaviour pPB;
    private void Awake()
    {
        pPB = presurePlate.GetComponent<PressurePlateBehaviour>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pPB.activated)
        {
            player.transform.position = new Vector3(1.3f, 150.1f, 3.0f);
            mixers[0].audioMixer.SetFloat("Volume F", -80.0f);
            mixers[1].audioMixer.SetFloat("Volume I", -80.0f);
            mixers[2].audioMixer.SetFloat("Volume O", -5.0f);
        }
    }
}
