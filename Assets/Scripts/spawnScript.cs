using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject bomberEnemy;
    public GameObject scoutEnemy;
    public GameObject orbEnemy;
    public float spawnTime = 3;
    public Renderer renderer;

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
        int instances = Random.Range(1, 8);
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
        int instances = Random.Range(1, 4);
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
        int instances = Random.Range(1, 2);
        for (int i = 0; i < instances; i++)
        {
            float x1 = transform.position.x - renderer.bounds.size.x / 2;
            float x2 = transform.position.x + renderer.bounds.size.x / 2;
            Vector2 spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

            Instantiate(orbEnemy, spawnPoint, Quaternion.identity);
        }
    }

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
