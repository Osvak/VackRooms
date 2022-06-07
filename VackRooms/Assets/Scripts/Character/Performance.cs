using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Performance : MonoBehaviour
{
    public bool loadAsylum;
    public bool unLoadFirstPuzzle;
    public bool unLoadSecondPuzzle;
    private bool firstRoomLoadOneTime;
    public GameObject puzzleFirstRoom;
    public GameObject wallToBlockFirstPuzzle;
    public GameObject wallToBlockSecondPuzzle;
    public GameObject puzzleSecondRoom;
    public List<GameObject> GameObjectsToDesactivateWhenSecondPuzzle = new List<GameObject>();
    public List<GameObject> FloorsFirstPuzzle = new List<GameObject>();
    public List<GameObject> FloorsSecondPuzzle = new List<GameObject>();
    public List<GameObject> FloorsThirdPuzzle = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        puzzleFirstRoom.gameObject.SetActive(false);
        puzzleSecondRoom.gameObject.SetActive(false);
        firstRoomLoadOneTime = false;
        wallToBlockFirstPuzzle.SetActive(false);
        wallToBlockSecondPuzzle.SetActive(false);
        for(int i = 0; i<GameObjectsToDesactivateWhenSecondPuzzle.Count; i++)
        {
            GameObjectsToDesactivateWhenSecondPuzzle[i].SetActive(false);
        }
        for (int l = 0; l < FloorsFirstPuzzle.Count; l++)
        {
            FloorsFirstPuzzle[l].SetActive(true);
        }
        for (int k = 0; k < FloorsSecondPuzzle.Count; k++)
        {
            FloorsSecondPuzzle[k].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(loadAsylum && !firstRoomLoadOneTime)
        {
            puzzleFirstRoom.gameObject.SetActive(true);
            puzzleSecondRoom.gameObject.SetActive(true);
            for (int i = 0; i < GameObjectsToDesactivateWhenSecondPuzzle.Count; i++)
            {
                GameObjectsToDesactivateWhenSecondPuzzle[i].SetActive(true);
            }
            for (int l = 0; l < FloorsFirstPuzzle.Count; l++)
            {
                FloorsFirstPuzzle[l].SetActive(true);
            }
            firstRoomLoadOneTime = true;
        }
        if(unLoadFirstPuzzle)
        {
            wallToBlockFirstPuzzle.SetActive(true);
            puzzleFirstRoom.SetActive(false);
            for(int i = 0; i < FloorsFirstPuzzle.Count; i++)
            {
                FloorsFirstPuzzle[i].SetActive(false);
            }
        }
        if (unLoadSecondPuzzle)
        {
            wallToBlockSecondPuzzle.SetActive(true);
            puzzleSecondRoom.SetActive(false);
            for (int i = 0; i < GameObjectsToDesactivateWhenSecondPuzzle.Count; i++)
            {
                GameObjectsToDesactivateWhenSecondPuzzle[i].SetActive(false);
            }
            for (int k = 0; k < FloorsSecondPuzzle.Count; k++)
            {
                FloorsSecondPuzzle[k].SetActive(false);
            }
        }
    }
}
