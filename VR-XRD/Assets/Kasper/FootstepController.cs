using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class FootstepController : MonoBehaviour
{
    public AudioClip footstepSound;
    private AudioSource audioSource;
    private CharacterController characterController;
    public GameObject Vignette;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
        Vignette.SetActive(false);
    }

    private void Update()
    {
       // var isGrounded = characterController.isGrounded;

        var playerSpeed = characterController.velocity.magnitude;

        if ( playerSpeed > 1f && !audioSource.isPlaying)
        {
            audioSource.Play();
            Vignette.SetActive(true);
        }
        else if ( playerSpeed <= 0.1f && audioSource.isPlaying)
        {
            audioSource.Stop();
            Vignette.SetActive(false);
        }
    }
}