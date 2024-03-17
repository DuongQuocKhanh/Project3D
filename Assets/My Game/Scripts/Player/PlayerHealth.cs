using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class PlayerHealth : MonoBehaviour
{
    private Ragdoll ragdoll;
    private ActiveWeapon activeWeapon;
    private CharactorAiming characterAiming;
    private VolumeProfile postProcessing;
    private Vignette vignette;
    private Vector3 direction;
    private Animator amin;
    private CharacterController characterController;
    
   

    public float currentHealth;
    public float maxHealth;
    private bool isDead = false;




    // Start is called before the first frame update
 

    void Start()
    {
        currentHealth = maxHealth;
        ragdoll = GetComponent<Ragdoll>();
        characterAiming = GetComponent<CharactorAiming>();
        amin = GetComponent<Animator>();
        postProcessing = FindObjectOfType<Volume>().profile;
        activeWeapon = GetComponent<ActiveWeapon>();
        characterController = GetComponent<CharacterController>();

    }

    
    public void PlayerHitDamage(float takedamage)
    {
        currentHealth -= takedamage;
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_HURT);
        }

        if (currentHealth <= 0)
        {
            amin.SetBool("IsDead", true);
            amin.enabled = false;
            characterAiming.enabled = false;
            activeWeapon.DropWeapon();
            characterController.enabled = false;
           
            PlayerDie();
            isDead = true;
        }
        
       
    }

    public void PlayerDie()
    {
       
       
        DOVirtual.DelayedCall(2f, () =>
        {
            if (UIManager.HasInstance)
            {
                string message = "Lose";
                UIManager.Instance.ShowPopup<PopupMessage>(data: message);
            }
        });
       
        //Cursor.lockState = CursorLockMode.None;
        //Object.Destroy(gameObject, 0.5f);
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void OnHealth(float amount)
    {
        if (postProcessing.TryGet(out Vignette vignette))
        {
            float percent = 1.0f - (currentHealth / maxHealth);
            vignette.intensity.value = percent * 0.4f;
        }
    }

    public void TakeHealth(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        OnHealth(amount);
    }


 

}
