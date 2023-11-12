using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class NpcMovementController : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float patrollingRange;
    [SerializeField] private List<Transform> waypoints;

    private NavMeshAgent _navMeshAgent;
    private Vector3 _wayPoint;
    private bool _isWayPointSet;
    private Transform _currentWaypoint;


    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Check if the agent has reached its destination
        if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.1f)
        {
            StartCoroutine(WaitAndSetRandomDestination(4f));
        }
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
    
    IEnumerator WaitAndSetRandomDestination(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Call the function to set a new random destination
        SetRandomDestination();
    }
}