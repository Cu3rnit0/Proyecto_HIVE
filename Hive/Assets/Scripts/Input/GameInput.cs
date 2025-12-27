using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance;

    [Header("Mobile (Opcional)")]
    public VirtualJoystick moveJoystick;
    public LookInput lookInput;

    private float lookX;
    private float lookY;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); //Importante para cambios de escena
    }

    void Update()
    {
        ReadLookInput();
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
    public float LookX => lookX;
    public float LookY => lookY;

    private void ReadLookInput()
    {
        float mouseX = 0f;
        float mouseY = 0f;

#if UNITY_STANDALONE || UNITY_EDITOR
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
#endif

        float touchX = lookInput != null ? lookInput.LookDelta.x : 0f;
        float touchY = lookInput != null ? lookInput.LookDelta.y : 0f;

        lookX = mouseX + touchX;
        lookY = mouseY + touchY;
    }
}
