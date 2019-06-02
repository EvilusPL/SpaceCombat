using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    public GameObject enemy; // Variable to store the enemy prefab
    public float spawnTime = 2; // Variable to konow how fast we should create new enemies
    public Renderer renderer;   // Renderer component of the spawn object

    // Start is called before the first frame update
    void Start()
    {
        Invoke("addEnemy", spawnTime);
    }

    // Function for spawning enemies
    void addEnemy()
    {
        renderer = GetComponent<Renderer>();

        float x1 = transform.position.x - renderer.bounds.size.x / 2;
        float x2 = transform.position.x + renderer.bounds.size.x / 2;
        Vector2 spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

        Instantiate(enemy, spawnPoint, Quaternion.identity);
        if (spawnTime > 0.0f)
        {
            spawnTime = spawnTime - 0.01f;
            Invoke("addEnemy", spawnTime);
        } else
        {
            sceneSwitcher sceneSwitcher = new sceneSwitcher();
            sceneSwitcher.GotoMainMenu();
        }
        
    }
}
