using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class Move : MonoBehaviour
{
    [SerializeField] float walkSpeed = 2f;
    Vector2 moveInput;
    CharacterController controller;
    float velocityY = 0f;
    [SerializeField] float gravityMulti = 1;
    [SerializeField] float jumpForce = 1;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        //Gravity
        velocityY += Physics.gravity.y * Time.deltaTime * gravityMulti;

        if (controller.isGrounded && velocityY < 0)
        {
            velocityY = -1;          
        }

        //Movement
        Vector3 movement = transform.forward * moveInput.y
        + transform.right * moveInput.x;

        movement *= walkSpeed;
        movement.y = velocityY;

        controller.Move(movement * Time.deltaTime);
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnJump(InputValue value)
    {
        if(controller.isGrounded)
            velocityY = jumpForce;
    }
}
