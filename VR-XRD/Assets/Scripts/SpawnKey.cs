using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    public GameObject key;
    // Start is called before the first frame update

    public void Spawn(Component sender, object data)
    {
        var transform1 = transform;
        Instantiate(key, transform1.position, transform1.rotation);
    }
}