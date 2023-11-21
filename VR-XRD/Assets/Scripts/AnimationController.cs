using UnityEngine;
using UnityEngine.AI;

namespace Kutaiba.Scripts
{
    public class AnimationController : MonoBehaviour
    {
        private Animator _animator;
        private NavMeshAgent _navMeshAgent;
        private static readonly int Speed = Animator.StringToHash("Speed");

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            MovingAnimation();
        }

        private void MovingAnimation()
        {
            var speed = _navMeshAgent.velocity.magnitude;
            _animator.SetFloat(Speed, speed);
        }
    }
}