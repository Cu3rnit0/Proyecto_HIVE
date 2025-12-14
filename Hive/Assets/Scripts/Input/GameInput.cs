using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance;

    [Header("Mobile")]
    public VirtualJoystick moveJoystick;
    public LookInput lookInput;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // =========================
    // MOVIMIENTO
    // =========================
    public float MoveX
    {
        get
        {
            float keyboard = Input.GetAxis("Horizontal");
            float joystick = moveJoystick != null ? moveJoystick.Horizontal : 0f;
            return Mathf.Clamp(keyboard + joystick, -1f, 1f);
        }
    }

    public float MoveY
    {
        get
        {
            float keyboard = Input.GetAxis("Vertical");
            float joystick = moveJoystick != null ? moveJoystick.Vertical : 0f;
            return Mathf.Clamp(keyboard + joystick, -1f, 1f);
        }
    }

    // =========================
    // MIRAR (CÁMARA)
    // =========================
    public float LookX
    {
        get
        {
            float mouse = Input.GetAxis("Mouse X");
            float touch = lookInput != null ? lookInput.LookDelta.x : 0f;
            return mouse + touch;
        }
    }

    public float LookY
    {
        get
        {
            float mouse = Input.GetAxis("Mouse Y");
            float touch = lookInput != null ? lookInput.LookDelta.y : 0f;
            return mouse + touch;
        }
    }
}
