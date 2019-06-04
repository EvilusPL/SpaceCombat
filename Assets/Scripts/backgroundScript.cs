using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScript : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float speed = -0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
