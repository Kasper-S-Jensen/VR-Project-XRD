using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Arrow_Spawner : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform notch;
    public float arrowRespawnTime = 1f;

    private XRGrabInteractable _bow;
    private bool _arrowNotched;
    private GameObject _currentArrow;


    // Start is called before the first frame update
    void Start()
    {
        _bow = GetComponent<XRGrabInteractable>();
        PullInteraction.PullActionReleased += NotchEmpty;
    }

    private void OnDestroy()
    {
        PullInteraction.PullActionReleased -= NotchEmpty;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_bow.isSelected)
        {
            case true when _arrowNotched == false:
                _arrowNotched = true;
                StartCoroutine("DelayedSpawn");
                break;
            case false when _currentArrow != null:
                Destroy(_currentArrow);
                NotchEmpty(1f);
                break;
        }
    }

    private void NotchEmpty(float value)
    {
        _arrowNotched = false;
        _currentArrow = null;
    }

   private IEnumerator DelayedSpawn()
    {
        yield return new WaitForSeconds(arrowRespawnTime);
        _currentArrow = Instantiate(arrowPrefab, notch.transform);

    }
}