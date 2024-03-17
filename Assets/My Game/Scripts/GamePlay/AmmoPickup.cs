using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int magazineSize = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_AMMOPICK);
        }
        ActiveWeapon playerWeapon = other.GetComponent<ActiveWeapon>();
        if (playerWeapon)
        {
            playerWeapon.RefillMagazine(magazineSize);
            Destroy(this.gameObject);
        }
       
    }
}
