using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summoned_mob : MonoBehaviour
{
    public float attackRange = 2f; // Range at which the character can attack enemies
    public int damagePerHit = 10; // Damage dealt per hit to enemies
    public float attackCooldown = 1f; // Cooldown between each attack

    private float lastAttackTime; // Time when the last attack occurred

    private void Update()
    {
        // Check if enough time has passed since the last attack
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            // Find all enemies in range
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRange);

            // Loop through all colliders found
            foreach (Collider2D collider in colliders)
            {
                // Check if the collider belongs to an enemy
                hp_handler enemyHealth = collider.GetComponent<hp_handler>();
                if (enemyHealth != null)
                {
                    // Deal damage to the enemy
                    enemyHealth.TakeDamage(damagePerHit);
                }
            }

            // Update the time of the last attack
            lastAttackTime = Time.time;
        }
    }

    // Draw a gizmo to visualize the attack range in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
