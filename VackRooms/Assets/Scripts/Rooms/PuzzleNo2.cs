using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleNo2 : MonoBehaviour
{
    public GameObject companionCube;
    public GameObject room;
    public GameObject tripod;
    public GameObject cCSpawnPoint;
    public GameObject toPuzzle2;
    public GameObject toPuzzle3;

    [SerializeField]
    private CompanionCubeBehaviour cCB;
    [SerializeField]
    private bool asserted = true;

    private void Awake()
    {
        cCB = companionCube.GetComponent<CompanionCubeBehaviour>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cCB.touched && asserted)
        {
            room.SetActive(true);
            tripod.SetActive(false);
            toPuzzle2.SetActive(false);
            toPuzzle3.SetActive(true);
            companionCube.transform.position = cCSpawnPoint.transform.position;
            asserted = false;
        }
    }
}
