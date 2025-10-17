using UnityEngine;

public class spwanmanager : MonoBehaviour
{
    public GameObject enemyPrefab;    // Enemy prefab to spawn
    public Transform spawnPoint;      // Where to spawn (can be empty GameObject)
    public float spawnInterval = 10f; // Time between spawns
    public int maxSpawns = 4;         // How many times to spawn

    private int spawnCount = 0;

    void Start()
    {
        // Start repeating spawn calls
        InvokeRepeating("SpawnEnemy", 2f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (spawnCount >= maxSpawns)
        {
            CancelInvoke("SpawnEnemy"); // Stop spawning
            return;
        }

        // Spawn enemy
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        spawnCount++;
    }
}
