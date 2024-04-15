using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SummonHealthHandler : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the summon
    public int currentHealth; // Current health of the summon
    public GameObject deathParticlesPrefab; // Reference to the death particles prefab
    public GameObject damageTextPrefab; // Reference to the damage text prefab

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; // Set current health to max health at the start
    }

    // Function to handle damage taken by the summon
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce health by the specified damage amount

        // Check if the summon has run out of health
        if (currentHealth <= 0)
        {
            Die(); // Call the Die function if health is zero or below
        }

        // Instantiate damage text prefab to display damage taken
        InstantiateDamageText(damage);
    }

    // Function to handle summon's death
    private void Die()
    {
        // Instantiate death particles
        Instantiate(deathParticlesPrefab, transform.position, Quaternion.identity);

        // Destroy the summon GameObject
        Destroy(gameObject);
    }

    private void InstantiateDamageText(int damage)
    {
        // Instantiate damage text prefab at the summon's position
        GameObject damageTextObject = Instantiate(damageTextPrefab, transform.position, Quaternion.identity);

        // Get the TextMeshPro component from the instantiated prefab
        TextMeshPro damageText = damageTextObject.GetComponentInChildren<TextMeshPro>();

        if (damageText != null)
        {
            // Set the text of the damage text to display the damage amount
            damageText.text = damage.ToString();
        }
        else
        {
            Debug.LogWarning("TextMeshPro component not found in the instantiated damage text prefab.");
        }
    }
}
