using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizer : MonoBehaviour
{
    
    private AudioSource audioSource;
    private float detectionRangeMin;
    private float detectionRangeMax;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        detectionRangeMin = audioSource.minDistance;
        detectionRangeMax = audioSource.maxDistance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.color = Color.yellow;
        var position = transform.position;
        Gizmos.DrawWireSphere(position, detectionRangeMin);
        Gizmos.DrawWireSphere(position, detectionRangeMax);
    }
}
