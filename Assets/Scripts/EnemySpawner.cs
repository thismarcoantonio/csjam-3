using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject portalSprite;
    public List<GameObject> spawners = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();
    public float spawnRate;

    private float spawnTimer = 0;

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnRate)
        {
            HandleSpawn();
        }
    }

    private void HandleSpawn()
    {
        Transform currentSpawner = spawners[Random.Range(0, spawners.Count)].GetComponent<Transform>();
        GameObject currentEnemy = enemies[Random.Range(0, enemies.Count)];

        GameObject createdPortal = Instantiate(portalSprite, currentSpawner.position, currentSpawner.rotation);
        Instantiate(currentEnemy, currentSpawner.position, currentSpawner.rotation);

        Destroy(createdPortal, 1f);

        spawnTimer = 0;
    }
}
