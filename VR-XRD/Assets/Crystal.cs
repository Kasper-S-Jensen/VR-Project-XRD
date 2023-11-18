using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Crystal : MonoBehaviour
{
    // Start is called before the first frame update
    public void GemGrabbed()
    {
        StoryManager.instance.UpdateStoryState();
    }
}
