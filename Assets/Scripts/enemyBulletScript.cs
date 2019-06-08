using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletScript : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public GameObject explosion;
    public int speed = -6;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(0, speed);
    }

    void Update()
    {
        if (rigidbody2D.position.y < -5.5)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string name = collision.gameObject.name;

        if ((name == "spaceship") || (name == "spaceship(Clone)"))
        {
            if (spaceShipScript.isImmortal == false)
            {
                GameObject exp = Instantiate(explosion, new Vector2(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y), Quaternion.identity);
                spaceShipScript.respawnTime = Time.time + 2f;
                Destroy(collision.gameObject);
                Destroy(exp, 1);

                scoreScript.livesCount--;

                GameObject exp2 = Instantiate(explosion, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
                Destroy(exp2, 1);
                Destroy(gameObject);
            }
        }
    }
}
