using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceShipScript : MonoBehaviour
{

    public Rigidbody2D rigidbody2D;
    public GameObject bullet;
    public Sprite spaceship1, spaceship2, spaceship3;
    public static float respawnTime = 3f;
    public static bool isImmortal;

    private float immortabilityTime;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        immortabilityTime = Time.time + 3f;
        isImmortal = true;
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f); 
    }

    void Update()
    {
        if (scoreScript.powerCount < 10)
            GetComponent<SpriteRenderer>().sprite = spaceship1;
        if ((scoreScript.powerCount >= 10) && (scoreScript.powerCount < 30))
            GetComponent<SpriteRenderer>().sprite = spaceship2;
        if (scoreScript.powerCount >= 30)
            GetComponent<SpriteRenderer>().sprite = spaceship3;

        if (Time.time > immortabilityTime)
        {
            isImmortal = false;
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (rigidbody2D.position.x <= 8)
                rigidbody2D.velocity = new Vector2(10, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (rigidbody2D.position.x >= -8)
                rigidbody2D.velocity = new Vector2(-10, 0);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (rigidbody2D.position.y <= 5)
                rigidbody2D.velocity = new Vector2(0, 10);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (rigidbody2D.position.y >= -5)
                rigidbody2D.velocity = new Vector2(0, -10);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0, 0);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (scoreScript.powerCount < 5)
                Instantiate(bullet, transform.position, Quaternion.identity);
            if ((scoreScript.powerCount >= 5) && (scoreScript.powerCount < 10))
                for (int i=1; i<3; i++)
                    Instantiate(bullet, new Vector2(transform.position.x - i, transform.position.y), Quaternion.identity);
            if (scoreScript.powerCount >= 20)
                for (int i = 1; i < 4; i++)
                    Instantiate(bullet, new Vector2(transform.position.x - i, transform.position.y), Quaternion.identity);
        }   

        rigidbody2D.position = new Vector2(Mathf.Clamp(rigidbody2D.position.x, -8f, 8f), Mathf.Clamp(rigidbody2D.position.y, -5f, 5f));

    }
}
