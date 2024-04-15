using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHandler : MonoBehaviour
{
    public float attackRange = 2f; // Range at which the enemy can attack summons
    public int damagePerHit = 10; // Damage dealt per hit to summons
    public float attackCooldown = 1f; // Cooldown between each attack

    private void Start()
    {
        // Start the coroutine for attacking with cooldown
        StartCoroutine(AttackWithCooldown());
    }

    private IEnumerator AttackWithCooldown()
    {
        // Infinite loop for continuous attacking
        while (true)
        {
            // Find all summons in range
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRange);

            // Initialize variables to track the nearest summon and its distance
            SummonHealthHandler nearestSummon = null;
            float nearestDistance = Mathf.Infinity;

            // Loop through all colliders found
            foreach (Collider2D collider in colliders)
            {
                // Check if the collider belongs to a summon
                SummonHealthHandler summonHealth = collider.GetComponent<SummonHealthHandler>();
                if (summonHealth != null)
                {
                    // Calculate the distance to the summon
                    float distance = Vector2.Distance(transform.position, collider.transform.position);

                    // If the distance is less than the nearest distance, update the nearest summon
                    if (distance < nearestDistance)
                    {
                        nearestSummon = summonHealth;
                        nearestDistance = distance;
                    }
                }
            }

            // If a nearest summon is found, deal damage to it
            if (nearestSummon != null)
            {
                nearestSummon.TakeDamage(damagePerHit);
            }

            // Wait for the specified attack cooldown before the next attack
            yield return new WaitForSeconds(attackCooldown);
        }
    }

    // Draw a gizmo to visualize the attack range in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}