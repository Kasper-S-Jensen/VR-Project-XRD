using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Kutaiba.Scripts
{
    public class BackgroundNpcAnimationController : MonoBehaviour
    {
        [SerializeField] private float changePoseWaitTime;
    
        private Animator _animator;
        private NavMeshAgent _navMeshAgent;
        private static readonly int PoseIndex = Animator.StringToHash("PoseIndex");
        private static readonly int NumberOfPoses = 2;

        private void Start()
        {
            changePoseWaitTime = 10f;
            _animator = GetComponent<Animator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            StartCoroutine(WaitAndSetRandomPose(changePoseWaitTime));
        }

        private void SetRandomPose()
        {
            var randomIndex = Random.Range(0, NumberOfPoses);
            _animator.SetInteger(PoseIndex, randomIndex);
        }
    
        private IEnumerator WaitAndSetRandomPose(float delay)
        {
            yield return new WaitForSeconds(delay);
            SetRandomPose();
        }
    }
}
