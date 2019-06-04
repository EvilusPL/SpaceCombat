using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    public GameObject enemy; // Variable to store the enemy prefab
    public GameObject bomberEnemy; // Same but for the bomber enemy
    public GameObject scoutEnemy; // Scout enemy
    public GameObject orbEnemy; // Orb enemy
    public float spawnTime = 3; // Variable to know how fast we should create new enemies
    public Renderer renderer;   // Renderer component of the spawn object

    // Start is called before the first frame update
    void Start()
    {
        Invoke("addEnemy", spawnTime);
    }

    void spawnRockEnemy()
    {
        float x1 = transform.position.x - renderer.bounds.size.x / 2;
        float x2 = transform.position.x + renderer.bounds.size.x / 2;
        Vector2 spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

        Instantiate(enemy, spawnPoint, Quaternion.identity);
    }

    void spawnBomberEnemy()
    {
        int instances = Random.Range(1, 10);
        for (int i=0; i<instances; i++)
        {
            float x1 = transform.position.x - renderer.bounds.size.x / 2;
            float x2 = transform.position.x + renderer.bounds.size.x / 2;
            Vector2 spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

            Instantiate(bomberEnemy, spawnPoint, Quaternion.identity);
        }
    }

    void spawnScoutEnemy()
    {
        int instances = Random.Range(1, 10);
        for (int i = 0; i < instances; i++)
        {
            float x1 = transform.position.x - renderer.bounds.size.x / 2;
            float x2 = transform.position.x + renderer.bounds.size.x / 2;
            Vector2 spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

            Instantiate(scoutEnemy, spawnPoint, Quaternion.identity);
        }
    }

    void spawnOrbEnemy()
    {
        int instances = Random.Range(1, 10);
        for (int i = 0; i < instances; i++)
        {
            float x1 = transform.position.x - renderer.bounds.size.x / 2;
            float x2 = transform.position.x + renderer.bounds.size.x / 2;
            Vector2 spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

            Instantiate(orbEnemy, spawnPoint, Quaternion.identity);
        }
    }

    // Function for spawning enemies
    void addEnemy()
    {
        renderer = GetComponent<Renderer>();
        int randomEnemy = Random.Range(0, 100);

        if (randomEnemy > 25)
            spawnRockEnemy();
        if ((randomEnemy > 25) && (randomEnemy < 50) && (Time.timeSinceLevelLoad > 10f))
            spawnBomberEnemy();
        if ((randomEnemy >= 50) && (randomEnemy < 75) && (Time.timeSinceLevelLoad > 20f))
            spawnScoutEnemy();
        if ((randomEnemy >= 75) && (Time.timeSinceLevelLoad > 30f))
            spawnOrbEnemy();

        if (spawnTime > 0.5f)
        {
            spawnTime = spawnTime - 0.01f;
        } else
        {
            spawnTime = 3f;
        }

        Invoke("addEnemy", spawnTime);

    }

    
}
