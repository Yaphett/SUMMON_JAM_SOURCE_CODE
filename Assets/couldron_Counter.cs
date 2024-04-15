using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class couldron_Counter : MonoBehaviour
{
    public float initialFloat = 0f; // The initial value of the float
    public float maxFloat = 10f; // The maximum value the float can reach
    public float floatIncreaseRate = 1f; // The base rate at which the float increases
    public float childMultiplier = 0.1f; // The multiplier to apply to the float increase rate based on the number of children

    public float currentFloat; // The current value of the float

    public GameObject[] creaturesToSummon; // Array of creature prefabs to summon

    private void Start()
    {
        currentFloat = initialFloat;
    }

    private void Update()
    {
        // Calculate the float increase rate based on the number of children
        float rateWithMultiplier = floatIncreaseRate + (transform.childCount * childMultiplier);

        // Increase the float over time
        currentFloat += rateWithMultiplier * Time.deltaTime;

        // Check if currentFloat reaches maxFloat
        if (currentFloat >= maxFloat)
        {
            // Summon a random creature
            SummonCreature();

            // Reset currentFloat
            currentFloat = 0f;
        }
    }

    private void SummonCreature()
    {
        // Choose a random creature to summon
        int randomIndex = Random.Range(0, creaturesToSummon.Length);
        GameObject creaturePrefab = creaturesToSummon[randomIndex];

        // Instantiate the chosen creature at the cauldron's position
        Instantiate(creaturePrefab, transform.position, Quaternion.identity);
    }
}
