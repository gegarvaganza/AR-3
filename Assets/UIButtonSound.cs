using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlaySound()
    {
        if (audioSource != null)
            audioSource.Play();
    }
}
