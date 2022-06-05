using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public string room;
    public float force;
    public InputActionReference wKey;
    GameObject player;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject;
        rb = player.GetComponent<Rigidbody>();
        wKey.action.performed += Move;
        wKey.action.canceled += Stop;
    }

    void Move(InputAction.CallbackContext obj)
    {
        rb.velocity = player.transform.forward * force;
    }

    void Stop(InputAction.CallbackContext obj)
    {
        rb.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        room = other.name;
    }
}
