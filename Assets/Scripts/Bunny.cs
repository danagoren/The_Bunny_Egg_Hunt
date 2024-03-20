using UnityEngine;

public class Bunny : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public AudioClip moveSound;
    public AudioSource audioSource;

    Animator animator;
    Vector2 joystickInput;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get joystick input from the OnScreenJoystick
        joystickInput = FindObjectOfType<OnScreenJoystick>().JoystickInput;

        // Move the bunny/player
        Move();
    }

    void Move()
    {
        // Move the bunny/player
        Vector3 movement = new Vector3(joystickInput.x, joystickInput.y, 0f);
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
        SetAnimatorPositions(movement);
    }

    void SetAnimatorPositions(Vector3 direction)
    {
        if (direction.x == 0 && direction.y == 0)
        {
            animator.SetBool("WalkRight", false);
            animator.SetBool("WalkLeft", false);
            animator.SetBool("WalkFront", false);
            animator.SetBool("WalkBack", false);
            return;
        }

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                animator.SetBool("WalkRight", true);
                animator.SetBool("WalkLeft", false);
                animator.SetBool("WalkFront", false);
                animator.SetBool("WalkBack", false);
            }
            else
            {
                animator.SetBool("WalkRight", false);
                animator.SetBool("WalkLeft", true);
                animator.SetBool("WalkFront", false);
                animator.SetBool("WalkBack", false);
            }
        }
        else
        {
            if (direction.y > 0)
            {
                animator.SetBool("WalkRight", false);
                animator.SetBool("WalkLeft", false);
                animator.SetBool("WalkFront", false);
                animator.SetBool("WalkBack", true);
            }
            else
            {
                animator.SetBool("WalkRight", false);
                animator.SetBool("WalkLeft", false);
                animator.SetBool("WalkFront", true);
                animator.SetBool("WalkBack", false);
            }
        }
    }

}
