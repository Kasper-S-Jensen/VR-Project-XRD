using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soup : MonoBehaviour
{
    // Start is called before the first frame update
    private bool chickenAdded;
    private bool carrotAdded;
    private bool soupDone;
    private GameEvent questCompleted;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chickenleg"))
        {
            Destroy(collision.gameObject);
            chickenAdded = true;
        }

        if (collision.gameObject.CompareTag("Carrot"))
        {
            Destroy(collision.gameObject);
            carrotAdded = true;
        }
    }

    private void Update()
    {
        if (!chickenAdded || !carrotAdded || soupDone)
        {
            return;
        }

        StoryManager.instance.UpdateStoryState();
        soupDone = true;
    }
}