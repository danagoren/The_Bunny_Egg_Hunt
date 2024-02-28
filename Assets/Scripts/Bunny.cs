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

    void Movement()
    {
        Vector2 bunnyPos = (Vector2)gameObject.transform.position;
        Vector2 mousePosWorld = Vector2.zero;
        Vector2 mousePosScreen = Vector2.zero;

        //if bunny reached its destination - stop.
        if ((Math.Abs(target.x - bunnyPos.x) < 0.1) && (Math.Abs(target.y - bunnyPos.y) < 0.1))
        {
            RB.velocity = Vector2.zero;
        }

        //if player clicks on screen - bunny moves towards where the player clicked.
        if (Input.GetMouseButtonDown(0))
        {
            mousePosScreen = Input.mousePosition;
            mousePosWorld = AdjustPos(Camera.main.ScreenToWorldPoint(mousePosScreen));
            //Debug.Log("mousePosScreen: " + mousePosScreen + ", mousePosWorld: " + mousePosWorld);
            if (!IsWalkable(mousePosScreen, mousePosWorld)) //check if the player clicked over the panel / borders
            {
                return;
            }
            bunnyPos = (Vector2)gameObject.transform.position;
            RB.velocity = (mousePosWorld - bunnyPos).normalized * speed;
            target = mousePosWorld;
        }

        AnimatorPositions(RB.velocity); //setting bools for the animations
        //Debug.Log("bunnyPos = " + bunnyPos + ", mousePos = " + mousePos + ", target = " + target);
    }

    //adjust the position to bring the bunny's legs to the target instead of its belly
    Vector2 AdjustPos(Vector2 Pos)
    {
        Pos.y += 1f;
        return Pos;
    }

    //check if the player clicked over the panel / borders
    bool IsWalkable(Vector2 mousePosScreen, Vector2 mousePosWorld)
    {
        if (mousePosScreen.y >= 791f) //if crossed the panel
        {
            return false;
        }
        /*if (mousePosWorld.y <= -9.7) //if crossed bottom border
        {
            return false;
        }
        if (mousePosWorld.x >= 12 || mousePosWorld.x <= -15.1) //if crossed side borders
        {
            return false;
        }*/
        return true;
    }

    //setting bools for the animations
    void AnimatorPositions(Vector3 direction)
    {
        //PlayerPrefs.SetInt("Astro", 1); //for testing
        if (PlayerPrefs.GetInt("Astro") == 1)
        {
            animator.SetBool("Astro", true);
        }
        else
        {
            animator.SetBool("Astro", false);
        }
        if (PlayerPrefs.GetInt("Rocker") == 1)
        {
            animator.SetBool("Rocker", true);
        }
        else
        {
            animator.SetBool("Rocker", false);
        }
        if (PlayerPrefs.GetInt("Rain") == 1)
        {
            animator.SetBool("Rain", true);
        }
        else
        {
            animator.SetBool("Rain", false);
        }

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
            /*if (PlayerPrefs.GetInt("Astro") == 1)
            {
                gameObject.transform.localScale = new Vector3(-0.6f, 0.55f, 1);
            }*/
            return;
        }
        if ((-direction.x) > Math.Abs(direction.y))
        {
            animator.SetBool("WalkRight", false);
            animator.SetBool("WalkLeft", true);
            animator.SetBool("WalkFront", false);
            animator.SetBool("WalkBack", false);
            /*if (PlayerPrefs.GetInt("Astro") == 1)
            {
                gameObject.transform.localScale = new Vector3(0.6f, 0.55f, 1);
            }*/
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
