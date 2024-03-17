using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float healthPickup = 50f;




    private void OnTriggerEnter(Collider other)
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_HEALTHPICK);
        }

        PlayerHealth health = other.GetComponent<PlayerHealth>();
        if (health)
        {
            health.TakeHealth(healthPickup);
            Destroy(this.gameObject);
        }
       
    }
}
