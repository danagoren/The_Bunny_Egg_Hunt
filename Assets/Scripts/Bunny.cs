using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Bunny : MonoBehaviour
{
    private Rigidbody2D RB;
    private float speed = 5.0f;
    private static Vector2 target = Vector2.zero;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void OnMouseDown()
    {

    }

    void Movement()
    {
        Vector2 bunnyPos = (Vector2)gameObject.transform.position;
        Vector2 mousePos = Vector2.zero;

        //if bunny reached its destination - stop.
        if ((Math.Abs(target.x - bunnyPos.x) < 0.1) && (Math.Abs(target.y - bunnyPos.y) < 0.1))
        {
            RB.velocity = Vector2.zero;
        }

        //if player clicks on screen - bunny moves towards where the player clicked.
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = AdjustPos(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            bunnyPos = (Vector2)gameObject.transform.position;
            RB.velocity = (mousePos - bunnyPos).normalized * speed;
            target = mousePos;
        }

        float moveDirectionH = Input.GetAxis("Horizontal");
        float moveDirectionV = Input.GetAxis("Vertical");
        Vector3 direction = RB.velocity;

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

        //Debug.Log("bunnyPos = " + bunnyPos + ", mousePos = " + mousePos + ", target = " + target);
    }

    //adjusts position: this function is needed to bring the bunny's legs to the target instead of its belly
    Vector2 AdjustPos (Vector2 Pos)
    {
        Pos.y += 1f;
        return Pos;
    }
}
