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