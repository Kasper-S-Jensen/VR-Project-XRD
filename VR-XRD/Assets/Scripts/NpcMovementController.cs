using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class NpcMovementController : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float waitingDelayTime;
    [SerializeField] private float detectionRange;
    [SerializeField] private LayerMask targetMask;

    private NavMeshAgent _navMeshAgent;
    private Vector3 _wayPoint;
    private bool _isWayPointSet;
    private Transform _currentWaypoint;
    private GameObject _player;
    public AudioClip footstepSound;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        waitingDelayTime = 4f;
        _player = GameObject.FindGameObjectWithTag("Player");
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        PlayFootsteps();
        var isInRange = PlayerInRange();
        if (!isInRange)
        {
            Patrole();
        }
        else
        {
            GoToPlayer();
        }
    }

    private void PlayFootsteps()
    {
        var playerSpeed = _navMeshAgent.velocity.magnitude;

        if (playerSpeed > 1f && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if (playerSpeed <= 0.1f && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    private void Patrole()
    {
        if (_navMeshAgent.pathPending || !(_navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance)) return;
        StartCoroutine(WaitAndSetRandomDestination(waitingDelayTime));
        SetRandomDestination();
    }

    private void GoToPlayer()
    {
        var position = _player.transform.position;
        _navMeshAgent.SetDestination(position);
        var lookAtTarget =
            new Vector3(position.x, transform.position.y, position.z);
        transform.LookAt(lookAtTarget);
    }

    private void SetRandomDestination()
    {
        if (!(_navMeshAgent.velocity.sqrMagnitude < 0.01f)) return;

        do
        {
            var randomIndex = Random.Range(0, waypoints.Count);

            _currentWaypoint = waypoints[randomIndex];
        } while (_currentWaypoint == transform);

        _navMeshAgent.SetDestination(_currentWaypoint.position);
    }

    private IEnumerator WaitAndSetRandomDestination(float delay)
    {
        yield return new WaitForSeconds(delay);
        SetRandomDestination();
    }

    private bool PlayerInRange()
    {
        return Physics.CheckSphere(transform.position, detectionRange, targetMask);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        var position = transform.position;
        Gizmos.DrawWireSphere(position, detectionRange);
    }
}