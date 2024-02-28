using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorAiming : MonoBehaviour
{
    public float turnSpeed = 15f;
    public float aimDuration = 0.3f;
    public AxisState xAxis;
    public AxisState yAxis;
    public Transform cameraLookAt;
    private Camera mainCamera;
    private Animator animator;
    private ActiveWeapon activeWeapon;
    private int isAimingParam = Animator.StringToHash("IsAiming");
    private bool isAiming;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false; // Hàm ẩn con chuột
        Cursor.lockState = CursorLockMode.Locked; // Hàm khoá con chuột
        animator = GetComponent<Animator>();
        activeWeapon = GetComponent<ActiveWeapon>();
    }
    private void Update()
    {
        isAiming = Input.GetMouseButton(1);
        animator.SetBool(isAimingParam, isAiming);

        var weapon = activeWeapon.GetActiveWeapon();
        if (weapon != null)
        {
            weapon.weaponRecoil.recoilModifier = isAiming ? 0.3f : 1.0f;
        }

      

        //        //if (isAiming)
        //        //{
        //        //    weapon.weaponRecoil.recoilModifier = 0.3f;
        //        //}
        //        //else
        //        //{
        //        //    weapon.weaponRecoil.recoilModifier = 1f;
        //        //}
        //    }
    }


    void FixedUpdate() // hàm Update này giúp cho ra nhiều frame
        {
            xAxis.Update(Time.fixedDeltaTime);
            yAxis.Update(Time.fixedDeltaTime);
            cameraLookAt.eulerAngles = new Vector3(yAxis.Value, xAxis.Value, 0);

            float yawCamera = mainCamera.transform.rotation.eulerAngles.y; // eulerAngles là góc , yaw là góc y của camera
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.fixedDeltaTime); // Slerp giúp cho góc quay mình nó mượt
        }
    

}
