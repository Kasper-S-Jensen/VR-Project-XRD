using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _animator;
    private static readonly int leverActivated = Animator.StringToHash("leverActivated");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }


    public void OpenGate()
    {
      

        _animator.SetBool(leverActivated, true);
    }

    public void CloseGate()
    {
        _animator.SetBool(leverActivated, false);
    }
}