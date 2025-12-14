using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 move =
            transform.right * GameInput.Instance.MoveX +
            transform.forward * GameInput.Instance.MoveY;

        controller.Move(move * speed * Time.deltaTime);
    }
}
