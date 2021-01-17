using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonLook : MonoBehaviour
{
    public Camera thirdPersonCamera;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float cameraYEuler = thirdPersonCamera.transform.rotation.eulerAngles.y;

        transform.rotation = Quaternion.Euler(0f, cameraYEuler, 0f);
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
