using UnityEngine;
using System.Collections;

public class ARDanceController : MonoBehaviour
{
    public static ARDanceController Current;

    private Animator animator;
    private AudioSource audioSource;

    [Header("Fade Settings")]
    public float fadeDuration = 1.5f; // seconds

    void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        Current = this;
    }

    void OnDisable()
    {
        if (Current == this)
            Current = null;
    }

    public void PlayDance()
    {
        animator.SetTrigger("Dance");

        if (audioSource != null)
        {
            audioSource.volume = 1f;
            audioSource.Play();
        }
    }

    // 👇 CALLED BY ANIMATION EVENT
    public void FadeOutMusic()
    {
        if (audioSource != null)
            StartCoroutine(FadeOutCoroutine());
    }

    IEnumerator FadeOutCoroutine()
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0f)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume; // reset for next dance
    }
}
