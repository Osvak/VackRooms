using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public InputActionReference horizontalLook;
    public InputActionReference verticalLook;
    public float lookSpeed = 1f;
    public Transform cameraTransform;
    float pitch;
    float yaw;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        horizontalLook.action.performed += HandleHorizontalLookChange;
        verticalLook.action.performed += HandleVerticalLookChange;
    }

    void HandleHorizontalLookChange(InputAction.CallbackContext obj)
    {
        yaw += obj.ReadValue<float>();
        transform.localRotation = Quaternion.AngleAxis(yaw, Vector3.up);
    }

    void HandleVerticalLookChange(InputAction.CallbackContext obj)
    {
        pitch -= obj.ReadValue<float>();
        pitch = Mathf.Clamp(pitch, -90, 90);
        cameraTransform.localRotation = Quaternion.AngleAxis(pitch, Vector3.right);
    }
}
