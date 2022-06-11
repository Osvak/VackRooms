using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleNo3 : MonoBehaviour
{
    public GameObject presurePlate;
    public GameObject player;

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
        }
    }
}
