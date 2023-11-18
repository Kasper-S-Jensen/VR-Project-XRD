using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FinalDoor : MonoBehaviour
{
    public XRGrabInteractable XRGrabInteractable;


    public void onKeyPlaced()
    {
        XRGrabInteractable.enabled = true;
    }
    
}
