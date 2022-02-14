using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    float speed = 4.0f;
    DateTime startTime = DateTime.UtcNow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        DateTime currentTime = DateTime.UtcNow;
        if (currentTime.CompareTo(startTime.AddSeconds(1)) > 0)
        {
            Vector2 position = transform.position;
            position.x = position.x + speed * Time.deltaTime;
            transform.position = position;
        }
    }
}
