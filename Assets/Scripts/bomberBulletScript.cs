using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomberBulletScript : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public GameObject explosion;
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

    // When the enemy's bullet collides with another object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string name = collision.gameObject.name; // Name of the object that collided with the enemy

        if ((name == "spaceship") || (name == "spaceship(Clone)")) // If collided with spaceship
        {
            // Start coroutine with explosion and generating new instance of object
            GameObject exp = Instantiate(explosion, new Vector2(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y), Quaternion.identity);
            spaceShipScript.respawnTime = Time.time + 2f;
            // Destroy the spaceship and explosion
            Destroy(collision.gameObject);
            Destroy(exp, 1);

            // Decrease lives count
            scoreScript.livesCount--;

            // And destroy the enemy of course with the instance of explosion
            GameObject exp2 = Instantiate(explosion, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            Destroy(exp2, 1);
            Destroy(gameObject);
        }
    }
}
