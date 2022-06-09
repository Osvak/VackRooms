using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsManager : MonoBehaviour
{
    public GameObject player;

    [SerializeField]
    private GameObject[] rooms;
    [SerializeField]
    private GameObject[] puzzleRooms;

    [SerializeField]
    private List<Transform> anchors;

    private PlayerMovement playerMovementScript;
    private string playerRoom;

    // Start is called before the first frame update
    void Start()
    {
        rooms = GameObject.FindGameObjectsWithTag("Room");
        puzzleRooms = GameObject.FindGameObjectsWithTag("PuzzleRoom");
        GameObject.Find("PuzzleRoom_No.3").SetActive(false);

        playerMovementScript = player.GetComponent<PlayerMovement>();

        playerRoom = playerMovementScript.room;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerRoom != playerMovementScript.room)
        {
            RoomDisplacementAlgorithm();
        }
    }

    private void RoomDisplacementAlgorithm()
    {
        playerRoom = playerMovementScript.room;
        GameObject actualRoom = GameObject.Find(playerRoom);
        anchors = new List<Transform>();

        for (int i = 1; i <= GameObject.Find(playerRoom).transform.Find("Anchors").childCount; i++)
        {
            anchors.Add(GameObject.Find(playerRoom).transform.Find("Anchors").Find("Anchor " + i));
        }

        int j = 0;
        for (int i = 0; i < rooms.Length; i++)
        {
            switch (actualRoom.tag)
            {
                case "Room":
                    if (rooms[i] != actualRoom)
                    {
                        rooms[i].transform.position = anchors[j].position;
                        j++;
                        for (int k = 0; k < puzzleRooms.Length; k++)
                        {
                            if (rooms[i].transform.position == puzzleRooms[k].transform.position && puzzleRooms[k].activeInHierarchy)
                            {
                                rooms[i].transform.position = new Vector3(3000, 0, 3000);
                            }
                        }
                    }
                    break;
                case "PuzzleRoom":
                    rooms[i].transform.position = anchors[j].position;
                    j++;
                    for (int k = 0; k < puzzleRooms.Length; k++)
                    {
                        if (rooms[i].transform.position == puzzleRooms[k].transform.position && puzzleRooms[k].activeInHierarchy)
                        {
                            rooms[i].transform.position = new Vector3(3000, 0, 3000);
                        }
                    }
                    break;
            }

        }
    }
}
