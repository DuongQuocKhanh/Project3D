using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ZombieHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    private bool isDead = false;
    private NavMeshAgent navMeshAgent;
    private Ragdoll ragdoll;
    private Zombie1 zombie;
    private Vector3 direction;


    private void Start()
    {
        currentHealth = maxHealth;
        ragdoll = GetComponent<Ragdoll>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        zombie = GetComponent<Zombie1>();
       
    }
    public void ZombieHitDamage(float takedamage)
    {
        currentHealth -= takedamage;
        if (currentHealth <= 0)
        {
           
            isDead = true;
            ZombieDie();


        }
    }

    public void ZombieDie()
    {
        //navMeshAgent.SetDestination(transform.position);
        zombie.visionRadius = 0f;
        zombie.attackingRadius = 0f;
        zombie.playerInvisionRadius = false;
        zombie.playerInattackingRadius = false;
        ragdoll.ActiveRagdoll();
        DisableAll();
        Object.Destroy(gameObject, 5f);



        //Cursor.lockState = CursorLockMode.None;

    }

    public bool IsDead()
    {
        return isDead;
    }

    public void DisableAll()
    {
        var allComponents = GetComponents<MonoBehaviour>();

        foreach (var comp in allComponents)
        {
            comp.enabled = false;
        }

        navMeshAgent.enabled = false;
    }

}

   
    

   
