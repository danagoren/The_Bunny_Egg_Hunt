using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Bunny : MonoBehaviour
{
    private Rigidbody2D RB;
    private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
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
        Vector2 bunnyPos = Vector2.zero;
        Vector2 mousePos = Vector2.zero;
        Vector2 target = mousePos;

        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            bunnyPos = gameObject.transform.position;
            RB.velocity = (mousePos - bunnyPos).normalized * speed;
        }
        else { return; }
        if ((Math.Abs(target.x - ((Vector2)gameObject.transform.position).x) < 1) && (Math.Abs(target.y - ((Vector2)gameObject.transform.position).y) < 1))
        {
            RB.velocity = Vector2.zero;
        }
        target = mousePos;
        Debug.Log("bunnyPos = " + bunnyPos + ", mousePos = " + mousePos + ", target = " + target);
    }
}
