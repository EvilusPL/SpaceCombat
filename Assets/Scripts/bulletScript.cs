﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

    public Rigidbody2D rigidbody2D;
    public const int speed = 6;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(0, speed);
    }

    void Update()
    {
        if (rigidbody2D.position.y > 5.5)
            Destroy(gameObject);
    }
}
