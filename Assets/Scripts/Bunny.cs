    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
using Terresquall;


public class Bunny : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public AudioClip moveSound;
    public AudioSource audioSource;

    private static Vector2 target = Vector2.zero;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        // Read input from the virtual joystick
        float horizontalInput = VirtualJoystick.GetAxis("Horizontal");
        float verticalInput = VirtualJoystick.GetAxis("Vertical");

        // Move the bunny/player
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // If there is movement, play the sound
        if (movement.magnitude > 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = moveSound;
                audioSource.Play();
            }
        }
        else
        {
            // Stop the sound if there is no movement
            audioSource.Stop();
        }

        // Set animator parameters based on movement direction
        AnimatorPositions(movement);
    }

    // Setting bools for the animations
    void AnimatorPositions(Vector3 direction)
    {
        if (direction.x == 0 && direction.y == 0)
        {
            animator.SetBool("WalkRight", false);
            animator.SetBool("WalkLeft", false);
            animator.SetBool("WalkFront", false);
            animator.SetBool("WalkBack", false);
            return;
        }

        if (direction.x > Math.Abs(direction.y))
        {
            animator.SetBool("WalkRight", true);
            animator.SetBool("WalkLeft", false);
            animator.SetBool("WalkFront", false);
            animator.SetBool("WalkBack", false);
            return;
        }

        if ((-direction.x) > Math.Abs(direction.y))
        {
            animator.SetBool("WalkRight", false);
            animator.SetBool("WalkLeft", true);
            animator.SetBool("WalkFront", false);
            animator.SetBool("WalkBack", false);
            return;
        }

        if (direction.y < 0)
        {
            animator.SetBool("WalkRight", false);
            animator.SetBool("WalkLeft", false);
            animator.SetBool("WalkFront", true);
            animator.SetBool("WalkBack", false);
            return;
        }

        if (direction.y > 0)
        {
            animator.SetBool("WalkRight", false);
            animator.SetBool("WalkLeft", false);
            animator.SetBool("WalkFront", false);
            animator.SetBool("WalkBack", true);
            return;
        }
    }
}
