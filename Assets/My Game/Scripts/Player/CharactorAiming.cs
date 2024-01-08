using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorAiming : MonoBehaviour
{
    public float turnSpeed = 15f;
    public float aimDuration = 0.3f;
    private Camera mainCamera;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false; // Hàm ẩn con chuột
        Cursor.lockState = CursorLockMode.Locked; // Hàm khoá con chuột
    }




    void FixedUpdate() // hàm Update này giúp cho ra nhiều frame
    {
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y; // eulerAngles là góc , yaw là góc y của camera
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.fixedDeltaTime); // Slerp giúp cho góc quay mình nó mượt
    }

}
