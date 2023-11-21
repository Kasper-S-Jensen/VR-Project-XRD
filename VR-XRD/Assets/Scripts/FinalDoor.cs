using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FinalDoor : MonoBehaviour
{
    public XRSocketInteractor keyholeInteractor;
    public XRGrabInteractable doorGrabInteractable;

    private void Start()
    {
        if (keyholeInteractor == null)
        {
            return;
        }

        keyholeInteractor.selectEntered.AddListener(OnKeyPlaced);
        keyholeInteractor.selectExited.AddListener(OnKeyRemoved);
    }

    private void OnKeyPlaced(SelectEnterEventArgs arg0)
    {
        gameObject.isStatic = false;
        doorGrabInteractable.interactionLayers = LayerMask.GetMask("Default");
    }

    private void OnKeyRemoved(SelectExitEventArgs arg0)
    {
        doorGrabInteractable.interactionLayers = LayerMask.GetMask("Ignore Raycast");
    }
}