using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public ZombieHealth ZbHealth;

    public void OnRayCastHit(RaycastWeapon weapon, Vector3 direction)
    {
        ZbHealth.TakeDamage(weapon.damageAmount, direction);
    }
}
