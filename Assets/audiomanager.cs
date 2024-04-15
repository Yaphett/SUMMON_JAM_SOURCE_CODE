using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    // Singleton instance
    public static audiomanager instance;

    // Audio clips
    public List<AudioClip> soundEffects = new List<AudioClip>();

    // Audio source
    private AudioSource audioSource;

    private void Awake()
    {
        // Create a singleton instance
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Get the audio source component
        audioSource = GetComponent<AudioSource>();
    }

    // Play a sound effect by index
    public void PlaySoundEffect(int index)
    {
        if (index >= 0 && index < soundEffects.Count)
        {
            audioSource.PlayOneShot(soundEffects[index]);
        }
        else
        {
            Debug.LogWarning("AudioManager: Invalid sound effect index");
        }
    }

    // Play a sound effect by name
    public void PlaySoundEffect(string soundName)
    {
        AudioClip clip = soundEffects.Find(s => s.name == soundName);
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("AudioManager: Sound effect '" + soundName + "' not found");
        }
    }
}