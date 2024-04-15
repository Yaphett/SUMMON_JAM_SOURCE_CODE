using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loot_spawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; // Array of prefabs to spawn
    public int minPrefabsToSpawn = 1; // Minimum number of prefabs to spawn
    public int maxPrefabsToSpawn = 5; // Maximum number of prefabs to spawn
    public float spawnRadius = 5f; // Radius within which to spawn prefabs

    private void Start()
    {
        SpawnPrefabs();
    }

    private void SpawnPrefabs()
    {
        // Randomly determine the number of prefabs to spawn
        int numPrefabs = Random.Range(minPrefabsToSpawn, maxPrefabsToSpawn + 1);

        // Loop to spawn each prefab
        for (int i = 0; i < numPrefabs; i++)
        {
            // Generate a random angle around the enemy
            float angle = Random.Range(0f, 360f);
            Vector3 spawnDirection = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;

            // Calculate the spawn position based on the enemy's position and spawn radius
            Vector3 spawnPosition = transform.position + spawnDirection * Random.Range(0f, spawnRadius);

            // Check if the spawn position is clear of colliders
            if (!Physics.CheckSphere(spawnPosition, 0.5f)) // Adjust the radius of the collider check as needed
            {
                // Randomly choose a prefab from the loot table
                GameObject prefabToSpawn = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];

                // Spawn the chosen prefab at the generated position
                Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            }
        }
    }
}
