using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pumpkinPrefab;
    public GameObject MazePrefab;
    public float initSpawnRate = 2f;
    private float spawnRate;
    private float screenRightBound;
    private float screenLeftBound;

    private void Start()
    {
        spawnRate = initSpawnRate;

        screenLeftBound = Camera.main.ScreenToWorldPoint(new Vector3(0,0,0)).x;
        screenRightBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;

        InvokeRepeating("spawnEnemy", 0f, spawnRate);
    }

    void Update()
    {
        // Check if the GameManager exists to get the current level
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            AdjustSpawnRate(gameManager.currentLevel);
        }
    }

    public void AdjustSpawnRate(int level)
    {
        // Adjust the spawn interval based on the current level
        spawnRate = Mathf.Max(0.5f, initSpawnRate - (level - 1) * 0.2f);

        // Cancel the existing Invoke and restart it with the new interval
        CancelInvoke("SpawnEnemy");
        InvokeRepeating("SpawnEnemy", 0f, spawnRate);
    }

    private void spawnEnemy()
    {
        float randomX = Random.Range(screenLeftBound, screenRightBound);
        Vector2 spawnPosition = new Vector2(randomX, Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height,0)).y);

        Instantiate(pumpkinPrefab, spawnPosition, Quaternion.identity);
    }

    public void spawnMaze()
    {
        Vector2 spawnPos = new Vector2(0.6f, 8);

        Instantiate(MazePrefab, spawnPos, Quaternion.identity);
    }
}
