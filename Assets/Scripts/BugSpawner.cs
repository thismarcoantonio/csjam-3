using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    public float spawnRate;
    public List<Vector2> positions = new List<Vector2>();
    public List<GameObject> bugs = new List<GameObject>();

    private float spawnTimer;

    private void Start()
    {
        HandleSpawn();
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnRate)
        {
            HandleSpawn();
            spawnTimer = 0;
        }
    }

    private bool IsOdd()
    {
        List<int> possiblePositions = new List<int>() { 1, 2 };
        return possiblePositions[Random.Range(0, possiblePositions.Count)] == 1;
    }

    private void HandleSpawn()
    {
        Vector2 position = positions[Random.Range(0, positions.Count)];
        GameObject bug = bugs[Random.Range(0, bugs.Count)];
        bool isRight = IsOdd();
        bool isTop = IsOdd();

        Vector3 spawnPosition = new Vector3(isRight ? position.x : -position.x, isTop ? position.y : -position.y, 0);

        Instantiate(bug, spawnPosition, transform.rotation);
    }
}
