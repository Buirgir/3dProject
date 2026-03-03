using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerV2 : MonoBehaviour
{
    Vector2 move = Vector2.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnMove(InputValue value)
    {
        Animator anim = GetComponentInChildren<Animator>();

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

    // Update is called once per frame
    void Update()
    {
        Vector3 mv = Camera.main.transform.forward * move.y + Camera.main.transform.right * move.x;
        mv.y = 0;
        mv.Normalize();

        transform.Translate(mv * Time.deltaTime);

        GameObject model = transform.GetChild(0).gameObject;
        if (mv.magnitude > 0.1f)
            model.transform.forward = mv;
    }
}
