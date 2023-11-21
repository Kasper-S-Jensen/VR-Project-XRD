using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PullInteraction : XRBaseInteractable
{
    public static event Action<float> PullActionReleased;

    public Transform start, end;
    public GameObject notch;
    private float _pullAmount;

    private LineRenderer _lineRenderer;
    private IXRSelectInteractor _pullingInteractor = null;
    private AudioSource _audioSource;

    protected override void Awake()
    {
        base.Awake();
        _lineRenderer = GetComponent<LineRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void SetPullInteractor(SelectEnterEventArgs args)
    {
        _pullingInteractor = args.interactorObject;
    }

    public void Release()
    {
        PullActionReleased?.Invoke(_pullAmount);
        _pullingInteractor = null;
        _pullAmount = 0f;
        var localPosition = notch.transform.localPosition;
        localPosition =
            new Vector3(localPosition.x, localPosition.y, 0f);
        notch.transform.localPosition = localPosition;
        UpdateString();
        PlayReleaseSound();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
        if (updatePhase != XRInteractionUpdateOrder.UpdatePhase.Dynamic)
        {
            return;
        }

        if (!isSelected)
        {
            return;
        }

        var pullPosition = _pullingInteractor.transform.position;
        _pullAmount = CalculatePull(pullPosition);
        UpdateString();
    }

    private float CalculatePull(Vector3 pullPosition)
    {
        var pullDirection = pullPosition - start.position;
        var targetDirection = end.position - start.position;
        var maxLength = targetDirection.magnitude;
        targetDirection.Normalize();
        var pullValue = Vector3.Dot(pullDirection, targetDirection) / maxLength;
        return Mathf.Clamp(pullValue, 0f, 1f);
    }

    private void UpdateString()
    {
        var linePosition = Vector3.forward *
                           Mathf.Lerp(start.transform.localPosition.z, end.transform.localPosition.z, _pullAmount);
        var localPosition = notch.transform.localPosition;
        localPosition = new Vector3(localPosition.x, localPosition.y,
            linePosition.z + .2f);
        notch.transform.localPosition = localPosition;
        _lineRenderer.SetPosition(1, linePosition);
    }

    private void PlayReleaseSound()
    {
        if (_audioSource.clip != null)
        {
            _audioSource.Play();
        }
    }
}