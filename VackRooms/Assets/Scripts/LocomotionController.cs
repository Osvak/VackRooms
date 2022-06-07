using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{
    public XRController rightTpRay;
    public GameObject feet;
    public InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if(rightTpRay)
        {
            rightTpRay.gameObject.SetActive(CheckIfActivated(rightTpRay));
            feet.SetActive(CheckIfActivated(rightTpRay));
        }
    }

    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice,teleportActivationButton,out bool isActivated, activationThreshold);
        return isActivated;

    }
}
