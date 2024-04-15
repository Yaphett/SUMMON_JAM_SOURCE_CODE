using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_spawner : MonoBehaviour
{
    public GameObject characterPrefab; // Reference to the character prefab
    public Transform[] parentObjects; // Array of potential parent objects
    public float maxDistance = Mathf.Infinity; // Maximum distance to consider a parent object
    public currencyHandler ch;


    private void Update()
    {
        // Check if the player presses the "1" key
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Find the closest parent object to the player's location
            Transform closestParent = FindClosestParent();

            if (closestParent != null && ch.craftingMats >= 3)
            {
                // Spawn the character prefab
                GameObject character = Instantiate(characterPrefab, transform.position, Quaternion.identity);

                int randomNumber = Random.Range(4, 6 + 1);
                audiomanager.instance.PlaySoundEffect(randomNumber);

                // Parent the character to the closest parent object
                character.transform.parent = closestParent;
                ch.craftingMats -= 3;

            }
            else
            {
                Debug.LogWarning("No parent object found.");
            }
        }
    }

    private Transform FindClosestParent()
    {
        Transform closestParent = null;
        float closestDistance = maxDistance;

        // Iterate through each potential parent object
        foreach (Transform parentObject in parentObjects)
        {
            // Calculate the distance between the player and the parent object
            float distance = Vector3.Distance(transform.position, parentObject.position);

            // Check if the current parent object is closer than the closest one found so far
            if (distance < closestDistance)
            {
                closestParent = parentObject;
                closestDistance = distance;
            }
        }

        return closestParent;
    }
}
