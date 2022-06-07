using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public string room;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        room = other.name;
    }
}
