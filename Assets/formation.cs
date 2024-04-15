using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class formation : MonoBehaviour
{
    public Transform target; // The target object to follow
    public float minRadius = 2f; // The minimum radius of the circle formation
    public float maxRadius = 5f; // The maximum radius of the circle formation
    public float minMoveSpeed = 3f; // The minimum speed at which the objects move towards the target
    public float maxMoveSpeed = 7f; // The maximum speed at which the objects move towards the target
    public float arrivalThreshold = 0.1f; // The distance threshold at which the object stops moving
    public float radiusChangeSpeed = 1f; // The speed at which the radius changes

    private float currentRadius; // The current radius of the circle formation

    private void Start()
    {
        // Initialize the current radius to the minimum radius
        currentRadius = minRadius;

        // Start the coroutine to animate the radius
        StartCoroutine(AnimateRadius());
    }

    private void Update()
    {
        if (target != null)
        {
            // Calculate the number of objects forming the circle
            int numObjects = transform.childCount;
            if (numObjects > 0)
            {
                // Calculate the angle between each object
                float angleIncrement = 360f / numObjects;

                // Iterate through each object and position it in the circle formation
                for (int i = 0; i < numObjects; i++)
                {
                    float angle = i * angleIncrement * Mathf.Deg2Rad;
                    Vector2 positionOffset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * currentRadius;
                    Vector2 targetPosition = (Vector2)target.position + positionOffset;
                    Vector2 direction = (targetPosition - (Vector2)transform.GetChild(i).position).normalized;
                    float distanceToTarget = Vector2.Distance(transform.GetChild(i).position, targetPosition);

                    // Calculate a random move speed within the specified range
                    float moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);

                    // Check if the object is within the arrival threshold distance
                    if (distanceToTarget > arrivalThreshold)
                    {
                        transform.GetChild(i).Translate(direction * moveSpeed * Time.deltaTime);
                    }
                }
            }
        }
    }

    private IEnumerator AnimateRadius()
    {
        while (true)
        {
            // Increase the radius towards the maximum radius
            while (currentRadius < maxRadius)
            {
                currentRadius += radiusChangeSpeed * Time.deltaTime;
                yield return null;
            }

            // Decrease the radius towards the minimum radius
            while (currentRadius > minRadius)
            {
                currentRadius -= radiusChangeSpeed * Time.deltaTime;
                yield return null;
            }
        }
    }
}
