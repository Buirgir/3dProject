using UnityEngine;
using UnityEngine.InputSystem;

public class Look : MonoBehaviour
{
    float xRotation = 0;
    Vector2 LookInput;
    [SerializeField] Vector2 Sensitivity = Vector2.one;
    Camera head;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        head = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        xRotation += -LookInput.y * Sensitivity.y;
        head.transform.localEulerAngles = new(xRotation, 0, 0);
        transform.Rotate(Vector3.up, LookInput.x * Sensitivity.x);
        xRotation = Mathf.Clamp(xRotation, -90, 90);
    }

    void OnLook(InputValue value)
    {
        LookInput = value.Get<Vector2>();
    }
}
