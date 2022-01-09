using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    float speed;

    bool isInStartZone;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        speed = 4.0f;

        isInStartZone = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // do not read input here as FixedUpdate is not always running and inputs can be missed
        Vector2 position = rigidbody2d.position;
        if (isInStartZone)
        {
            // can only move right while in the start zone
            horizontal = Math.Max(Math.Abs(horizontal), Math.Abs(vertical));
            position.x = position.x + speed * horizontal * Time.deltaTime;
            rigidbody2d.MovePosition(position);
        }
        else
        {
            rigidbody2d.position = new Vector2(
                rigidbody2d.position.x + speed * horizontal * Time.deltaTime, 
                rigidbody2d.position.y);
            //position.x = position.x + speed * horizontal * Time.deltaTime;
            //position.y = position.y + speed * vertical * Time.deltaTime;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "StartZone")
        {
            isInStartZone = false;
            rigidbody2d.gravityScale = 1;
        }
    }
}
