using UnityEngine;

public class playSoundOnEnable : MonoBehaviour
{
    public int soundIndex = 0; // Index of the sound effect to play

    private void OnEnable()
    {
        audiomanager.instance.PlaySoundEffect(soundIndex);
    }
}