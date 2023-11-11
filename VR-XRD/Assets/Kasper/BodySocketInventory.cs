using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class bodySocket
{
    public GameObject gameObject;
    [Range(0.01f,1f)]
    public float heightRatio;
}

public class BodySocketInventory : MonoBehaviour
{
    public GameObject HMD;
    public List<bodySocket> bodySockets;

    private Vector3 _CurrentHMDPosition;
    private Quaternion _CurrentHMDRotation;
    // Update is called once per frame
    void Update()
    {
        _CurrentHMDPosition = HMD.transform.position;
        _CurrentHMDRotation = HMD.transform.rotation;
        foreach (var bodySocket in bodySockets)
        {
            UpdateBodySocketHeight(bodySocket);
        }
        UpdateSocketInventory();
    }

    private void UpdateBodySocketHeight(bodySocket bodySocket)
    {
        bodySocket.gameObject.transform.position = new Vector3(bodySocket.gameObject.transform.position.x, _CurrentHMDPosition.y * bodySocket.heightRatio, bodySocket.gameObject.transform.position.z);
    }

    private void UpdateSocketInventory()
    {
        transform.position= new Vector3(_CurrentHMDPosition.x,0,_CurrentHMDPosition.z);
        transform.rotation = new Quaternion(transform.rotation.x,_CurrentHMDRotation.y, transform.rotation.z, _CurrentHMDRotation.w);
    }
}
