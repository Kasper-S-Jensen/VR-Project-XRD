using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DisableGrabbingHandModel : MonoBehaviour
{
    public GameObject leftHandModel;
    public GameObject rightHandModel;

    // Start is called before the first frame update
    void Start()
    {
        var grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(HideGrabbingHandModel);
        grabInteractable.selectExited.AddListener(ShowGrabbingHandModel);
    }

    private void HideGrabbingHandModel(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("LeftHand"))
        {
            leftHandModel.SetActive(false);
        }

        if (args.interactorObject.transform.CompareTag("RightHand"))
        {
            rightHandModel.SetActive(false);
        }
    }

    private void ShowGrabbingHandModel(SelectExitEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("LeftHand"))
        {
            leftHandModel.SetActive(true);
        }

        if (args.interactorObject.transform.CompareTag("RightHand"))
        {
            rightHandModel.SetActive(true);
        }
    }
}