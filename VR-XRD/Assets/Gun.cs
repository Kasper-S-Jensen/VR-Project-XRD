using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour
{
    public Transform barrelEnd;
    public GameObject bulletPrefab;
    public float bulletForce = 500f;
    // Start is called before the first frame update
    void Start()
    {
        var grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(FireGun);
    }

    private void FireGun(ActivateEventArgs arg0)
    {
        var bullet = Instantiate(bulletPrefab, barrelEnd.position, barrelEnd.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(barrelEnd.forward * bulletForce);
        
    }
}
