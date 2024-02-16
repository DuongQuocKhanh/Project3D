using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float blinkDuration = 0.1f;

    
    private SkinnedMeshRenderer meshRenderer;
  

    void Start()
    {
        
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        
        currentHealth = maxHealth;
        SetupHixBox();
    }

    private void SetupHixBox()
    {
        var rigidBodies = GetComponentsInChildren<Rigidbody>();
        foreach (var rigidbody in rigidBodies)
        {
            rigidbody.gameObject.AddComponent<HitBox>().ZbHealth = this;
        }
    }

    public void TakeDamage(float damageAmount, Vector3 direction)
    {
        StartCoroutine(EnemyFlash());
        currentHealth -= damageAmount;
        
        if (currentHealth <= 0f)
        {
            Die(direction);
        }
    }

    private void Die(Vector3 direction)
    {
     
    }

    private IEnumerator EnemyFlash()
    {
        meshRenderer.material.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(blinkDuration);
        meshRenderer.material.DisableKeyword("_EMISSION");
        StopCoroutine(nameof(EnemyFlash));
    }
}
