using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthUpScript : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public int speed = -6;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody2D.position.y < -5.5)
            Destroy(gameObject);
    }

    // When the health bonus collides with another object (e.g. spaceship)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spaceship") // If collided with spaceship
        {
            // Increase lives count
            scoreScript.livesCount++;

            // And destroy the health pack
            Destroy(gameObject);
        }
    }
}
