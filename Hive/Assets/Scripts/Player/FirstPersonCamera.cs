using Unity.VisualScripting;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float sensitivity = 2f;
    public Transform playerBody;

    private float xRotation = 0f;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        float mouseX = GetLookInputX()* sensitivity; 
        float mouseY = GetLookInputY()* sensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    float GetLookInputX()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        return Input.GetAxis("Mouse X");
#else
        return Input.Getaxis("LookX"); //Touch Joystick
#endif 
    }

    float GetLookInputY()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        return Input.GetAxis("Mouse Y");
#else
        return Input.GetAxis("LookY");
#endif
    }
}
