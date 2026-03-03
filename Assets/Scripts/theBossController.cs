using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

public class theBossController : MonoBehaviour
{
    Vector2 move = Vector2.zero;
    [SerializeField] float rotationSpeed = 20;
    public void OnMove(InputValue value)
    {
        Animator anim = GetComponent<Animator>();

        move = value.Get<Vector2>();
        if (move.magnitude > 0.1f)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);            
        }
    }
    public void OnJump(InputValue value)
    {
        Animator anim = GetComponent<Animator>();



        anim.SetBool("isRunning", true);
    }
    public void Update()
    {
        Vector3 mv = Vector3.forward * move.y;
        transform.Translate(mv * Time.deltaTime);
        float angle = rotationSpeed * move.x;
        transform.Rotate(Vector3.up, angle * Time.deltaTime);
    }
    
}
