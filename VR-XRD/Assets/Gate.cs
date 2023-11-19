using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _animator;
    private static readonly int leverActivated = Animator.StringToHash("leverActivated");
    public AudioSource audioSource;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        
    }


    public void OpenGate()
    {
      audioSource.Play();
      _animator.SetBool(leverActivated, true);
    }

    public void CloseGate()
    {
        audioSource.Play();
        _animator.SetBool(leverActivated, false);
    }
}