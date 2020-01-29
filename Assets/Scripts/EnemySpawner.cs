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
        Debug.Log(spawnTimer);

        if (spawnTimer >= spawnRate)
        {
            Debug.Log(123);
            Transform currentSpawner = spawners[Random.Range(0, spawners.Count)].GetComponent<Transform>();
            GameObject currentEnemy = enemies[Random.Range(0, enemies.Count)];

            Instantiate(portalSprite, currentSpawner.position, currentSpawner.rotation);
            Instantiate(currentEnemy, currentSpawner.position, currentSpawner.rotation);

            spawnTimer = 0;
        }
    }
}
