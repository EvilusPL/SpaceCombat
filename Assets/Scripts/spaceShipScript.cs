using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceShipScript : MonoBehaviour
{

    public Rigidbody2D rigidbody2D;
    public GameObject bullet;

    public static float respawnTime;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
            Instantiate(bullet, transform.position, Quaternion.identity);
        }

        rigidbody2D.position = new Vector2(Mathf.Clamp(rigidbody2D.position.x, -8f, 8f), Mathf.Clamp(rigidbody2D.position.y, -5f, 5f));

    }
}
