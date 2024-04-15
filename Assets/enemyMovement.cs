using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public string targetTag = "SUMMON"; // Tag of the target object
    public float moveSpeed = 5f; // Movement speed of the enemy
    public float attackRange = 2f; // Attack range of the enemy

    private Transform targetPoint; // Target point for the enemy to move towards
    private bool isInAttackRange; // Flag to indicate if the enemy is within attack range

    private void Update()
    {
        // Find the nearest object with the specified tag
        FindNearestTarget();

        // If a target point is found, move towards it
        if (targetPoint != null)
        {
            // Calculate direction towards the target point
            Vector3 direction = (targetPoint.position - transform.position).normalized;

            // Check if the enemy is within attack range of the target
            float distanceToTarget = Vector3.Distance(transform.position, targetPoint.position);
            if (distanceToTarget <= attackRange)
            {

                // Set the flag to indicate that the enemy is in attack range
                isInAttackRange = true;

                // Implement attack logic here
                //Debug.Log("Attacking target!");
            }
            else
            {
                // Move towards the target point
                transform.position += direction * moveSpeed * Time.deltaTime;
                // Reset the flag if the enemy is not within attack range
                isInAttackRange = false;
            }
        }
    }

    private void FindNearestTarget()
    {
        // Find all objects with the specified tag
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);

        // If there are no targets, return
        if (targets.Length == 0)
        {
            targetPoint = null;
            return;
        }

        // Find the nearest target
        float minDistance = Mathf.Infinity;
        GameObject nearestTarget = null;
        foreach (GameObject target in targets)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestTarget = target;
            }
        }

        // Set the nearest target as the target point
        targetPoint = nearestTarget.transform;
    }

}
