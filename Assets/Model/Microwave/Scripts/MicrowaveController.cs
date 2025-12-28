using UnityEngine;

public class MicrowaveController : MonoBehaviour
{
    public Animator animator;
    public Material transparentMat; // The transparent material to apply

    // Store original materials per renderer
    private Renderer[] rends;
    private Material[][] originalMats;

    void Awake()
    {
        // Get all child renderers
        rends = GetComponentsInChildren<Renderer>();

        // Store original materials
        originalMats = new Material[rends.Length][];
        for (int i = 0; i < rends.Length; i++)
        {
            originalMats[i] = rends[i].sharedMaterials; // save originals
        }
    }

    public void Assemble()
    {
        if (animator != null && animator.isActiveAndEnabled)
            animator.Play("Assemble");
    }

    public void Disassemble()
    {
        if (animator != null && animator.isActiveAndEnabled)
            animator.Play("Disassemble");
    }

    public void NormalColor()
    {
        // Restore original materials
        for (int i = 0; i < rends.Length; i++)
        {
            rends[i].sharedMaterials = originalMats[i];
        }
    }

    public void TransparentColor()
    {
        // Apply transparent material to all slots in each renderer
        for (int i = 0; i < rends.Length; i++)
        {
            Material[] mats = rends[i].sharedMaterials;
            for (int j = 0; j < mats.Length; j++)
            {
                mats[j] = transparentMat;
            }
            rends[i].sharedMaterials = mats;
        }
    }
}
