using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioHandler : MonoBehaviour
{
    public AudioClip musicClip; // Reference to the music clip
    private AudioSource audioSource; // Reference to the AudioSource component

    // Start is called before the first frame update
    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Set the music clip and configure looping
        audioSource.clip = musicClip;
        audioSource.loop = true;

        // Start playing the music
        audioSource.Play();
    }
}
