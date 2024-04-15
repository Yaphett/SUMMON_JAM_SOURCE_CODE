using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array of enemy prefabs to spawn
    public float minSpawnRate = 1f; // Minimum spawn rate (in seconds)
    public float maxSpawnRate = 5f; // Maximum spawn rate (in seconds)

    private void OnEnable()
    {
        // Start spawning enemies
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        // Infinite loop for continuous spawning
        while (true)
        {
            // Randomly select an enemy prefab from the array
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            // Instantiate the selected enemy prefab at the spawner's position
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            // Randomly determine the spawn rate for the next enemy
            float spawnRate = Random.Range(minSpawnRate, maxSpawnRate);

            // Wait for the specified spawn rate before spawning the next enemy
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
