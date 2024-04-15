using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_Handler : MonoBehaviour
{

    public ParticleSystem particleSystem; // Reference to the Particle System
    public float baseEmissionRate = 10f; // The base emission rate
    public float maxEmissionRate = 100f; // The maximum emission rate
    public float childMultiplier = 5f; // The multiplier to apply to the emission rate based on the number of children

    private void Update()
    {
        // Calculate the emission rate based on the number of children
        float emissionRate = baseEmissionRate + (transform.childCount * childMultiplier);

        // Clamp the emission rate to the maximum value
        emissionRate = Mathf.Clamp(emissionRate, baseEmissionRate, maxEmissionRate);

        // Set the particle emission rate
        var emission = particleSystem.emission;
        emission.rateOverTime = emissionRate;

        // Example: Output the current emission rate value
        //Debug.Log("Current emission rate: " + emissionRate);
    }

}
