using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void PlayerHitDamage(float takedamage)
    {
        currentHealth -= takedamage;
        if(currentHealth <= 0)
        {
            PlayerDie();
            isDead = true;
        }
    }

    public void PlayerDie()
    {
        Cursor.lockState = CursorLockMode.None;
        Object.Destroy(gameObject, 0.5f);
    }

    public bool IsDead()
    {
        return isDead;
    }
   
}
