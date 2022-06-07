using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class XROffset : XRGrabInteractable
{
    //private Vector3 initialAttachLocalPos;
    //private Quaternion initialAttachLocalRot;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    if(!attachTransform)
    //    {
    //        GameObject grab = new GameObject("Grab Pivot");
    //        grab.transform.SetParent(transform, false);
    //        attachTransform = grab.transform;
    //    }
    //    initialAttachLocalPos = attachTransform.localPosition;
    //    initialAttachLocalRot = attachTransform.localRotation;

    //}

    //protected override void OnSelectEntered(XRBaseInteractor interactor)
    //{
    //    if(interactor is XRDirectInteractor)
    //    {
    //        attachTransform.position = interactor.transform.position;
    //        attachTransform.rotation = interactor.transform.rotation;
    //    }
    //    else
    //    {
    //        attachTransform.localPosition = initialAttachLocalPos;
    //        attachTransform.localRotation = initialAttachLocalRot;
    //    }
    //    base.OnSelectEntered(interactor);
    //}
    private Vector3 interactorPosition = Vector3.zero;
    private Quaternion interactorRotation = Quaternion.identity;

    protected override void OnSelectEntering(XRBaseInteractor interactor)
    {
        // the interactor in this case should be one of the hands

        base.OnSelectEntering(interactor);

        // we want to ignore the repositioning if this is a socket

        if (interactor.gameObject.GetComponent<XRSocketInteractor>())
            return;

        StoreInteractor(interactor);
        MatchAttachmentPoints(interactor);
    }


    private void StoreInteractor(XRBaseInteractor interactor)
    {
        interactorPosition = interactor.attachTransform.localPosition;
        interactorRotation = interactor.attachTransform.localRotation;
    }
    private void MatchAttachmentPoints(XRBaseInteractor interactor)
    {
        bool hasAttach = attachTransform != null;
        interactor.attachTransform.position = hasAttach ? attachTransform.position : transform.position;
        interactor.attachTransform.rotation = hasAttach ? attachTransform.rotation : transform.rotation;
    }

    protected override void OnSelectExiting(XRBaseInteractor interactor)
    {
        base.OnSelectExiting(interactor);

        // we want to ignore the repositioning if this is a socket

        if (interactor.gameObject.GetComponent<XRSocketInteractor>())
            return;

        ResetAttachmentPoint(interactor);
        ClearInteractor(interactor);
    }
    private void ResetAttachmentPoint(XRBaseInteractor interactor)
    {
        interactor.attachTransform.localPosition = interactorPosition;
        interactor.attachTransform.localRotation = interactorRotation;
    }

    private void ClearInteractor(XRBaseInteractor interactor)
    {
        interactorPosition = Vector3.zero;
        interactorRotation = Quaternion.identity;
    }
}
