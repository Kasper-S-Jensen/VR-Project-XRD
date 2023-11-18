using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PotionMaster : MonoBehaviour
{
    public GameObject initialTextBox;
    public GameObject soupDoneTextBox;
    [SerializeField] private float detectionRange;
    [SerializeField] private LayerMask targetMask;
    [SerializeField] private bool isPlayerInRange;
    private bool isQuestOneCompleted;
    private bool isQuestTwoCompleted;

    private void Awake()
    {
        initialTextBox.SetActive(false);
        soupDoneTextBox.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        /*if (isQuestOneCompleted)
        {
            initialTextBox.SetActive(true);
        }

        if (isQuestTwoCompleted && StoryManager.instance.GetCurrentEventIndex() == 2)
        {
            soupDoneTextBox.SetActive(true);
        }*/
    }

    public void QuestAdvance(Component sender, object data)
    {
        Debug.Log("index:" + data);
        if (data is not int index)
        {
            return;
        }

        if (index == 0)
        {
            initialTextBox.SetActive(true);
        }
        else if (index == 1)
        {
            soupDoneTextBox.SetActive(true);
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

    public void OnConfirmButtonClick(GameObject textBox)
    {
        textBox.SetActive(false);
    }
}