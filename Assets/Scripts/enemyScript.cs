using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public int speed = -5; // Speed of the enemy
    public Rigidbody2D rigidbody2D; // Rigidbody
    public GameObject explosion;
    public GameObject spaceship;
    

    // Start is called before the first frame update
    void Start()
    {
        // Get the rigidbody component
        rigidbody2D = GetComponent<Rigidbody2D>();

        // Add a vertical speed to the enemy
        rigidbody2D.velocity = new Vector2(0, speed);
    }

    void Update()
    {
        if (rigidbody2D.position.y < -5.5)
            Destroy(gameObject);

        if (GameObject.FindGameObjectWithTag("Spaceship") == null)
        {
            Instantiate(spaceship, new Vector2(0, -4), Quaternion.identity);
        }
    }

    // When the enemy collides with another object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string name = collision.gameObject.name; // Name of the object that collided with the enemy

        // If the enemy collided with a bullet
        if (name == "bullet(Clone)")
        {
            GameObject exp = Instantiate(explosion, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            // Destroy itself and the bullet
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Destroy(exp, 1);
            
            // Increase score count
            scoreScript.scoreCount++;

        } else if ((name == "spaceship") || (name == "spaceship(Clone)")) // If collided with spaceship
        {
            // Start coroutine with explosion and generating new instance of object
            GameObject exp = Instantiate(explosion, new Vector2(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y), Quaternion.identity);
            // Destroy the spaceship and explosion
            Destroy(collision.gameObject);
            Destroy(exp, 1);
            
            // Decrease lives count
            scoreScript.livesCount--;
        }
    }
}
