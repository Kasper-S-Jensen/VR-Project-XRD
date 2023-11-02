using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class standardEnemyAI : MonoBehaviour
{
   private static readonly int Speed = Animator.StringToHash("Speed");
   public int ExperienceOnDeath = 100;
    public LayerMask whatIsPlayer;


    //States
    public float sightRange, attackRange;
    public bool playerInSightRange;
    private NavMeshAgent _agent;

    private Transform _player, _theGate;

    private bool isQuitting;

    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float patrollingRange;
    
    private Vector3 _wayPoint;
    private bool _isWayPointSet;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").transform;
//        _theGate = GameObject.FindWithTag("TheGate").transform;
        _agent = GetComponent<NavMeshAgent>();
    }


    private void Start()
    {
        CheckState();
    }

    private void Update()
    {
        CheckState();
    }

    private void OnDestroy()
    {
        if (isQuitting)
        {
            return;
        }

     //   OnEnemyDeath.Raise(ExperienceOnDeath);
    }

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }


    //debugging
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        var position = transform.position;
        Gizmos.DrawWireSphere(position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(position, sightRange);
    } // ReSharper disable Unity.PerformanceAnalysis
     void CheckState()
    {
        var position = transform.position;
        PlayerRange(position);
        
        if (playerInSightRange)
        {
            ChasePlayer();
        }
    }

    private void PlayerRange(Vector3 position)
    {
        playerInSightRange = Physics.CheckSphere(position, sightRange, LayerMask.NameToLayer("whatIsPlayer"));
    }

    private void ChasePlayer()
    {
        _agent.SetDestination(_player.position);
    }

    private void Patrole()
    {
        if (!_isWayPointSet) SetWayPoint();
        if (_isWayPointSet) _agent.SetDestination(_wayPoint);
        var distanceBetween = transform.position - _wayPoint;
        if (distanceBetween.magnitude < 1f) _isWayPointSet = false;

    }

    private void SetWayPoint()
    {
        var x = Random.Range(-patrollingRange, patrollingRange);
        var z = Random.Range(-patrollingRange, patrollingRange);

        var position = transform.position;
        _wayPoint = new Vector3(position.x + x,
            position.y, position.z + z);

        if (Physics.Raycast(_wayPoint, -transform.up, 2f, groundMask))
            _isWayPointSet = true;
    }
}
