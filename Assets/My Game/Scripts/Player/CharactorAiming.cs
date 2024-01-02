using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorAiming : MonoBehaviour
{
    public float turnSpeed = 15f;
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; // Hàm ẩn con chuột
        Cursor.lockState = CursorLockMode.Locked; // Hàm khoá con chuột
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y; //eulerAngles là góc , yaw là góc y của cam
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.fixedDeltaTime); // Slerp giúp cho góc quay nó mượt
    }

}
