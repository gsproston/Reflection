using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    bool isInStartZone;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

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
            horizontal = Math.Max(Math.Abs(horizontal), Math.Abs(vertical));
            position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        }
        else
        {
            position.x = position.x + 3.0f * horizontal * Time.deltaTime;
            position.y = position.y + 3.0f * vertical * Time.deltaTime;
        }
        rigidbody2d.MovePosition(position);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "StartZone")
        {
            isInStartZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "StartZone")
        {
            isInStartZone = false;
        }
    }
}
