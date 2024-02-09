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

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        target = Movement(target);
    }

    void OnMouseDown()
    {

    }

    Vector2 Movement(Vector2 target)
    {
        Vector2 bunnyPos = (Vector2)gameObject.transform.position;
        Vector2 mousePos = Vector2.zero;

        //if bunney reached its destination - stop.
        if ((Math.Abs(target.x - bunnyPos.x) < 0.2) && (Math.Abs(target.y - bunnyPos.y) < 0.2))
        {
            RB.velocity = Vector2.zero;
        }

        //if player clicks on screan - bunney moves towards where the player clicked.
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = AdjustPos(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            bunnyPos = (Vector2)gameObject.transform.position;
            RB.velocity = (mousePos - bunnyPos).normalized * speed;
            target = mousePos;
        }

        //Debug.Log("bunnyPos = " + bunnyPos + ", mousePos = " + mousePos + ", target = " + target);
        return target;
    }

    Vector2 AdjustPos (Vector2 Pos)
    {
        Pos.y += 1.4f;
        return Pos;
    }
}
