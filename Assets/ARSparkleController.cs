using UnityEngine;

public class ARSparkleController : MonoBehaviour
{
    public ParticleSystem sparkleEffect;

    private bool isPlaying = false;

    void Awake()
    {
        if (sparkleEffect == null)
            sparkleEffect = GetComponentInChildren<ParticleSystem>();
    }

    public void ToggleSparkle()
    {
        if (sparkleEffect == null) return;

        if (isPlaying)
        {
            sparkleEffect.Stop();
        }
        else
        {
            sparkleEffect.Play();
        }

        isPlaying = !isPlaying;
    }
}
