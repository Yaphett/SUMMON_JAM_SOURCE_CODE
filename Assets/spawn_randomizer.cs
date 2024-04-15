using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_randomizer : MonoBehaviour
{
    public GameObject[] objectsToRandomize; // Array of game objects to randomize
    public float randomizeInterval = 5f; // Time interval for randomizing (in seconds)

    private float timer; // Timer to track time for randomization

    void Start()
    {
        // Initialize the timer
        timer = randomizeInterval;

        // Randomly activate an initial object
        RandomizeObject();
    }

    void Update()
    {
        // Update the timer
        timer -= Time.deltaTime;

        // Check if it's time to randomize again
        if (timer <= 0f)
        {
            // Randomize the object
            RandomizeObject();

            // Reset the timer
            timer = randomizeInterval;
        }
    }

    void RandomizeObject()
    {
        // Randomly select an object from the array
        int randomIndex = Random.Range(0, objectsToRandomize.Length);
        GameObject selectedObject = objectsToRandomize[randomIndex];

        // Check if the selected object is inactive
        if (!selectedObject.activeSelf)
        {
            // Activate the selected object
            selectedObject.SetActive(true);
        }
    }
}
