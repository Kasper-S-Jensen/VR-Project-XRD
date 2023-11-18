using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Kutaiba.Scripts
{
    public class PrisonerAnimationController : MonoBehaviour
    {
        private Animator _animator;
        private readonly float _animationDelay = 6.0f;
        private bool _isAngry;
        private bool _isHitting;
        private static readonly int Angry = Animator.StringToHash("Angry");
        private static readonly int Hitting = Animator.StringToHash("Angry");

        private void Start()
        {
            _isAngry = false;
            _isHitting = false;
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            StartCoroutine(SetAnimation(_animationDelay));
        }

        private IEnumerator SetAnimation(float delay)
        {
            yield return new WaitForSeconds(delay);
            SetRandomAnimation();
        }

        private void SetRandomAnimation()
        {
            var random = Random.Range(0, 2);
            switch (random)
            {
                case 1:
                    _animator.SetInteger(Angry, random);
                    break;
                case 2:
                    _animator.SetInteger(Hitting, random);
                    break;
                default:
                    _animator.SetInteger(Angry, 0);
                    _animator.SetInteger(Hitting, 0);
                    break;
            }
        }
    }
}