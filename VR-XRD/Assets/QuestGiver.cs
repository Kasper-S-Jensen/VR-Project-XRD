using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public GameObject textBox;
    public GameObject gemFoundDialog;
    [SerializeField] private float detectionRange;
    [SerializeField] private LayerMask targetMask;
    [SerializeField] private bool isPlayerInRange;

    private void Awake()
    {
        textBox.SetActive(false);
        gemFoundDialog.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInRange();
        if (isPlayerInRange)
        {
            if (StoryManager.instance.GetCurrentEventIndex() == 0)
            {
                textBox.SetActive(true);
            }
            else if (StoryManager.instance.GetCurrentEventIndex() == 3)
            {
                gemFoundDialog.SetActive(true);
            }
        }
    }

    private void PlayerInRange()
    {
        isPlayerInRange = Physics.CheckSphere(transform.position, detectionRange, targetMask);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        var position = transform.position;
        Gizmos.DrawWireSphere(position, detectionRange);
    }

    public void OnConfirmButtonClick()
    {
        StoryManager.instance.UpdateStoryState();
        textBox.SetActive(false);
    }
    public void OnConfirmButtonClickAfterGemFound()
    {
        StoryManager.instance.UpdateStoryState();
        gemFoundDialog.SetActive(false);
    }
    
    public void QuestAdvance(Component sender, object data)
    {
        Debug.Log("wiz index:" + data);
        if (data is not int index)
        {
            return;
        }

        if (index == 2)
        {
            gemFoundDialog.SetActive(true);
        }
       
    }
}