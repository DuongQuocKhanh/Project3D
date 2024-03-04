using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth1 : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ZombieHitDamage(float takedamage)
    {
        currentHealth -= takedamage;
        if (currentHealth <= 0)
        {
            ZombieDie();
            isDead = true;
        }
    }

    public void ZombieDie()
    {
        Cursor.lockState = CursorLockMode.None;
        Object.Destroy(gameObject, 0.5f);
    }

    public bool IsDead()
    {
        return isDead;
    }
}
