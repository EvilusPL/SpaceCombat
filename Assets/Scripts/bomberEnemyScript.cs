﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class bomberEnemyScript : MonoBehaviour
{
    public int speed = -3;
    public Rigidbody2D rigidbody2D;
    public GameObject explosion;
    public GameObject spaceship;
    public GameObject enemyBullet;
    public GameObject healthUp;
    public GameObject powerUp;
    public float fireRateMin = 0.6f;
    public float fireRateMax = 0.9f;
    public int pointsForKillingEnemy = 5;

    private float nextFire = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        rigidbody2D.velocity = new Vector2(spaceship.transform.position.x, speed);

        if (gameObject.tag == "OrbEnemy")
            rigidbody2D.angularVelocity = Random.Range(-200, 200);

        nextFire = Time.time + Random.Range(fireRateMin, fireRateMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody2D.transform.position.x > spaceship.transform.position.x)
        {
            rigidbody2D.velocity = (spaceship.transform.position - rigidbody2D.transform.position).normalized * speed * -1f;
        }
        else
        {
            rigidbody2D.velocity = new Vector2(spaceship.transform.position.x, speed);
        }

        if (rigidbody2D.position.y < -5.5)
            Destroy(gameObject);

        if (Time.time > nextFire)
        {
            nextFire = Time.time + Random.Range(fireRateMin, fireRateMax);
            if (gameObject.tag == "OrbEnemy")
            {
                Instantiate(enemyBullet, transform.position, transform.rotation);
            } else
            {
                Instantiate(enemyBullet, transform.position, Quaternion.identity);
            }
        }

        if ((GameObject.FindGameObjectWithTag("Spaceship") == null) && (scoreScript.livesCount > 0))
        {
            if (Time.time > spaceShipScript.respawnTime)
                Instantiate(spaceship, new Vector2(0, -4), Quaternion.identity);
        }

        if (scoreScript.livesCount == 0)
        {
            Destroy(spaceship);
        }
    }

    // When the enemy collides with another object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string name = collision.gameObject.name; // Name of the object that collided with the enemy

        // If the enemy collided with a bullet
        if (name == "bullet(Clone)")
        {
            int bonusChance = Random.Range(0, 100);
            int healthUpChance = Random.Range(0, 100);
            int powerUpChance = Random.Range(0, 100);

            if (healthUpChance > 90)
            {
                if (healthUpChance > 90)
                    Instantiate(healthUp, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
                if (powerUpChance > 90)
                    Instantiate(powerUp, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            }

            GameObject exp = Instantiate(explosion, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            // Destroy itself and the bullet
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Destroy(exp, 1);

            // Increase score count
            scoreScript.scoreCount+=pointsForKillingEnemy;

        }
        else if ((name == "spaceship") || (name == "spaceship(Clone)")) // If collided with spaceship
        {
            // Start coroutine with explosion and generating new instance of object
            GameObject exp = Instantiate(explosion, new Vector2(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y), Quaternion.identity);
            spaceShipScript.respawnTime = Time.time + 3f;
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
