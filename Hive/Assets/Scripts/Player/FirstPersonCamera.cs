using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float sensitivity = 2f;
    public Transform playerBody;

    private float xRotation;

    void Update()
    {
        float lookX = GameInput.Instance.LookX * sensitivity;
        float lookY = GameInput.Instance.LookY * sensitivity;

        xRotation -= lookY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * lookX);
    }
}
