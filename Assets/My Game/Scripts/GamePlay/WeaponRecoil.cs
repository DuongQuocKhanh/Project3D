using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    [HideInInspector] // không muốn cho hiện ở editor thì mình dùng hàm này
    public CharactorAiming characterAiming;
    public CinemachineImpulseSource cameraShake;
    public Animator rigController;
    public Vector2[] recoilPattern;
    public float duration; // thời gian giựt là bao nhiêu để set ở editor
    public float recoilModifier = 1.0f;  // hành động mặc định nhắm thì nó sẽ giảm giật

    private float time;  // biến thời gian để set trong code
    private float verticalRecoil;
    private float horizontalRecoil;
    private int recoilIndex;

    private void Awake()
    {
        cameraShake = GetComponent<CinemachineImpulseSource>();
    }

    public void Reset()
    {
        recoilIndex = 0;
    }

    private int NextIndex(int index)
    {
        // cách 1
        //int newIndex = index++;
        //if(newIndex == recoilPattern.Length)
        //{
        //    newIndex = 0;
        //}
        //return newIndex;
        return (index + 1) % recoilPattern.Length; // cách 2 
    }

    public void GenerateRecoil(string weaponName)
    {
        time = duration;
        cameraShake.GenerateImpulse(Camera.main.transform.forward);

        horizontalRecoil = recoilPattern[recoilIndex].x;
        verticalRecoil = recoilPattern[recoilIndex].y;

        recoilIndex = NextIndex(recoilIndex);
        rigController.Play("weapon_recoil_" + weaponName, 1, 0.0f);
    }

    private void Update()
    {
        if (time > 0)
        {
            characterAiming.yAxis.Value -= (((verticalRecoil / 10) * Time.deltaTime) / duration) * recoilModifier;
            characterAiming.xAxis.Value -= (((horizontalRecoil / 10) * Time.deltaTime) / duration) * recoilModifier;
            time -= Time.deltaTime;
        }
    }
}
