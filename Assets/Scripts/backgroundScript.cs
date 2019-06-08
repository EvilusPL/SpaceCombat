using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScript : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float speed = -0.1f;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rigidbody2D.position.y <= -15)
        {
            rigidbody2D.velocity = new Vector2(0, -speed);
        } else if (rigidbody2D.position.y >= 15)
        {
            rigidbody2D.velocity = new Vector2(0, speed);
        }
    }
}
