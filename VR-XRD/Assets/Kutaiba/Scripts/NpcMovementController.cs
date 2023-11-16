using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class NpcMovementController : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float waitingDelayTime;

    private NavMeshAgent _navMeshAgent;
    private Vector3 _wayPoint;
    private bool _isWayPointSet;
    private Transform _currentWaypoint;


    private void Awake()
    {
        waitingDelayTime = 4f;
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.1f)
        {
            StartCoroutine(WaitAndSetRandomDestination(waitingDelayTime));
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

    private IEnumerator WaitAndSetRandomDestination(float delay)
    {
        yield return new WaitForSeconds(delay);
        SetRandomDestination();
    }
}