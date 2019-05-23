using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceShipScript : MonoBehaviour
{

    public Rigidbody2D rigidbody2D;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2D.velocity = new Vector2(10, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2D.velocity = new Vector2(-10, 0);
        } else
        {
            rigidbody2D.velocity = new Vector2(0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}
