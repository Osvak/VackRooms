using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCode : MonoBehaviour
{
    [SerializeField] private string name;
    public Performance performance;
    [SerializeField] private bool unLoadFirstPuzzle;
    [SerializeField] private bool unloadSecondPuzzle;
    public GameObject normalFloor;
    public List<GameObject> outsideFloor = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        name = gameObject.name;
        unLoadFirstPuzzle = false;
        unloadSecondPuzzle = false;
        for(int i = 0; i < outsideFloor.Count; i++)
        {
            outsideFloor[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(name == "CubeLocateSecondPuzzle")
        {
            unLoadFirstPuzzle=true;
        }
        if (name == "CubeLocateThirdPuzzle")
        {
            unloadSecondPuzzle = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enterd");
        if(other.tag == "Controller" && unLoadFirstPuzzle)
        {
            Debug.Log("Enter to colliders");
            performance.unLoadFirstPuzzle = true;
            unLoadFirstPuzzle = false;
            Destroy(this.gameObject);
        }
        {
            if (other.tag == "Controller" && unloadSecondPuzzle)
            {
                Debug.Log("Enter to colliders");
                performance.unLoadSecondPuzzle = true;
                unLoadFirstPuzzle = false;
                Destroy(this.gameObject);
                normalFloor.SetActive(false);
                for (int i = 0; i < outsideFloor.Count; i++)
                {
                    outsideFloor[i].SetActive(true);
                    outsideFloor[i].GetComponent<UnityEngine.XR.Interaction.Toolkit.TeleportationArea>().enabled = false;
                }
            }
        }
    }

}
