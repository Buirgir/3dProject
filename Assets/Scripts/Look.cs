using System;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class Look : MonoBehaviour
{
    public Camera LookCamera;
    float xRotation = 0;
    Vector2 LookInput;
    [SerializeField] Vector2 Sensitivity = Vector2.one;
    Camera head;
    [SerializeField] GameObject gun;
    
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
    void OnClick()
    {
        Animator gunAnimator = gun.GetComponent<Animator>();
        RaycastHit hit;
        if(gunAnimator.GetBool("IsShooting") != true)
        {
            gunAnimator.SetBool("IsShooting", true);
            if (Physics.Raycast(LookCamera.transform.position, LookCamera.transform.forward, out hit))
            {
                EnemyController enemyController = hit.transform.GetComponent<EnemyController>();
                if(enemyController != null)
                {
                    enemyController.Delete();
                }
                
            }
        }
    }
    public void OnAnimationEnd()
    {
        Animator gunAnimator = gun.GetComponent<Animator>();
        gunAnimator.SetBool("IsShooting", false);
    }
}

