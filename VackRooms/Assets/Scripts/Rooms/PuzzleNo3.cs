using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleNo3 : MonoBehaviour
{
    public GameObject presurePlate;

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
            Debug.Log("TE PASASTE EL GEIMU WEBON");
        }
    }
}
