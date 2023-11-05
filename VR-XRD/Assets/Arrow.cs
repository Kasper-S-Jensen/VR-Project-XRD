using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 10f;
    public Transform tip;

    private Rigidbody _rigidbody;
    private bool _inAir = false;
    private Vector3 _lastPosition = Vector3.zero;
    private ParticleSystem _particleSystem;
    private TrailRenderer _trailRenderer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        _trailRenderer = GetComponentInChildren<TrailRenderer>();

        PullInteraction.PullActionReleased += Release;
        Stop();
    }

    private void OnDestroy()
    {
        PullInteraction.PullActionReleased -= Release;
    }

    private void Release(float value)
    {
        PullInteraction.PullActionReleased -= Release;
        gameObject.transform.parent = null;
        _inAir = true;
        SetPhysics(true);
        var force = transform.forward * value * speed;
        _rigidbody.AddForce(force, ForceMode.Impulse);
        StartCoroutine(RotateWithVelocity());
        _lastPosition = tip.position;

        _particleSystem.Play();
        _trailRenderer.emitting = true;
    }


    private IEnumerator RotateWithVelocity()
    {
        yield return new WaitForFixedUpdate();
        while (_inAir)
        {
            var newRotation = Quaternion.LookRotation(_rigidbody.velocity, transform.up);
            transform.rotation = newRotation;
            yield return null;
        }
    }

    private void FixedUpdate()
    {
        if (!_inAir)
        {
            return;
        }

        CheckCollision();
        _lastPosition = tip.position;
    }

    private void CheckCollision()
    {
        if (!Physics.Linecast(_lastPosition, tip.position, out var hitInfo))
        {
            return;
        }

        if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Body"))
        {
            return;
        }

        if (hitInfo.transform.TryGetComponent(out Rigidbody body))
        {
            _rigidbody.interpolation = RigidbodyInterpolation.None;
            transform.parent = hitInfo.transform;
            body.AddForce(_rigidbody.velocity * 0.5f, ForceMode.Impulse);
        }

        Stop();
    }

    private void Stop()
    {
        _inAir = false;
        SetPhysics(false);

        _particleSystem.Stop();
        _trailRenderer.emitting = false;
    }

    private void SetPhysics(bool usePhysics)
    {
        _rigidbody.useGravity = usePhysics;
        _rigidbody.isKinematic = !usePhysics;
    }
}