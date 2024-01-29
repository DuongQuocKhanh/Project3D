using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.AI;
using UnityEngine.Rendering.UI;

public class Zombie1 : MonoBehaviour
{
    public float zombieDamge = 5f;
    public float timeAttack;
    private bool previousAttack;
    private RaycastHit hitInfo;
    


    public PlayerHealth playerHealth;
    public Camera cameraAttackingRaycast;
    public NavMeshAgent zombieAgent;
    public Transform lookPoint;
    public LayerMask playerLayer;
    public Transform playerBody;
    public Animator amin;

    public GameObject[] walkPoints;
    public float zombieSpeed;
    private int currentZombiePosition = 0;
    private float walkingpointRadius = 2;

    public float visionRadius;
    public float attackingRadius;
    public bool playerInvisionRadius;
    public bool playerInattackingRadius;


    private void Awake()
    {
        zombieAgent = GetComponent<NavMeshAgent>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        playerInvisionRadius = Physics.CheckSphere(transform.position, visionRadius, playerLayer);
        playerInattackingRadius = Physics.CheckSphere(transform.position, attackingRadius, playerLayer);

        if (!playerInvisionRadius && !playerInattackingRadius) Guard();
        if (playerInvisionRadius && !playerInattackingRadius) PursuePlayer();
        if (playerInvisionRadius && playerInattackingRadius) AttackPlayer();
    }

    private void Guard() // trạng thái chuẩn bị tấn công
    {
        if (Vector3.Distance(walkPoints[currentZombiePosition].transform.position, transform.position) < walkingpointRadius)
        {
            currentZombiePosition = Random.Range(0, walkPoints.Length);
            if(currentZombiePosition >= walkPoints.Length)
            {
                currentZombiePosition = 0;
            }
        }
        zombieAgent.SetDestination(walkPoints[currentZombiePosition].transform.position);
        //transform.position = Vector3.MoveTowards(transform.position, walkPoints[currentZombiePosition].transform.position, Time.deltaTime * zombieSpeed);
      
    }

    private void PursuePlayer()
    {
        if (zombieAgent.SetDestination(playerBody.position))
        {
            zombieAgent.speed = 4f; // set speed 
            amin.SetBool("Walking", false);
            amin.SetBool("Running", true);
            amin.SetBool("Attacking", false);
            
        }
        else
        {
            amin.SetBool("Walking", false);
            amin.SetBool("Running", false);
            amin.SetBool("Attacking", false);
            
        }
        
       

    }

    private void AttackPlayer()
    {
        zombieAgent.SetDestination(transform.position);
        transform.LookAt(lookPoint);
        if (!previousAttack)
        {
            if (Physics.Raycast(cameraAttackingRaycast.transform.position, cameraAttackingRaycast.transform.forward, out hitInfo, attackingRadius))
            {
                Debug.Log("Attacking" + hitInfo.transform.name);
                playerHealth = hitInfo.transform.GetComponent<PlayerHealth>();
                if(playerHealth != null)
                {
                    playerHealth.PlayerHitDamage(zombieDamge);
                }

                amin.SetBool("Walking", false);
                amin.SetBool("Running", false);
                amin.SetBool("Attacking", true);
            }

            previousAttack = true;
            Invoke(nameof(ActiveAttacking), timeAttack);
        }
    }

    private void ActiveAttacking()
    {
        previousAttack = false;
    }
}
