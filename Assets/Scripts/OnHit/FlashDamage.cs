using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashDamage : MonoBehaviour
{
    // Serialized Vars
    [SerializeField] Material flashMaterial;
    [SerializeField] private float duration;

    // Vars
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private Coroutine flashRoutine;

    private void Start()
    {
        // Store original material
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    public void Flash()
    {
        // Check if its running
        if(flashRoutine != null)
        {
            // Stop in case its running
            StopCoroutine(flashRoutine);
        }

        flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        // Switch material 'flash'
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(duration);
        // Go default
        spriteRenderer.material = originalMaterial;
        // Set null, to finish
        flashRoutine = null;
    }
}
