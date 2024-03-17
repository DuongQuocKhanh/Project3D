using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class ScreenGame : BaseScreen
{
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private TextMeshProUGUI magazineText;




    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }
    public override void Init()
    {
        base.Init();

            if (ListenerManager.HasInstance)
        {
            ListenerManager.Instance.Register(ListenType.UPDATE_AMMO, OnUpdateAmmo);
        }
    }

    public override void Show(object data)
    {
        base.Show(data);

        if (ListenerManager.HasInstance)
        {
            ListenerManager.Instance.Register(ListenType.UPDATE_AMMO, OnUpdateAmmo);
        }

        



    }

    public override void Hide()
    {

        base.Hide();
        if (ListenerManager.HasInstance)
        {
            ListenerManager.Instance.Unregister(ListenType.UPDATE_AMMO, OnUpdateAmmo);
        }
        

    }
    

    private void OnUpdateAmmo(object value)
    {
        if (value is RaycastWeapon weapon)
        {
            if (weapon.equipWeaponBy == EquipWeaponBy.Player)
            {
                ammoText.text = weapon.ammoCount.ToString();
                magazineText.text = weapon.magazineSize.ToString();
            }
        }
    }







}






