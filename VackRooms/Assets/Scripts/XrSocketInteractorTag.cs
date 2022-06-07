using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XrSocketInteractorTag : XRSocketInteractor
{
    public string targetTag1;
    public string targetTag2;
    public string targetTag3;
    public bool realoaded = false;

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        if(!realoaded) 
        {
            //realoaded = true;
            return base.CanSelect(interactable) && (interactable.CompareTag(targetTag1) || interactable.CompareTag(targetTag2) || interactable.CompareTag(targetTag3));
        }
        else
        {
            return false;
        } 
            
    }
    
}
