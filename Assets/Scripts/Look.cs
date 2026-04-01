using System;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class Look : MonoBehaviour
{
    public Camera LookCamera;
    public Camera ThirdPersonCamera;
    float xRotation = 0;
    Vector2 LookInput;

    [SerializeField]
    Vector2 Sensitivity = Vector2.one;
    Camera head;

    [SerializeField]
    GameObject gun;

    [SerializeField]
    TMP_Text killCount;
    int kills = 0;
    bool firstPerson = true;
    int trigger = 0;

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
        if (gunAnimator.GetBool("IsShooting") != true)
        {
            Camera shootCamera;
            gunAnimator.SetBool("IsShooting", true);
            if (firstPerson)
                shootCamera = LookCamera;
            else
                shootCamera = ThirdPersonCamera;
            if (
                Physics.Raycast(
                    shootCamera.transform.position,
                    shootCamera.transform.forward,
                    out hit
                )
            )
            {
                EnemyController enemyController = hit.transform.GetComponent<EnemyController>();
                if (enemyController != null)
                {
                    enemyController.Respawn();
                    kills++;
                    killCount.text = kills.ToString();
                }
            }
        }
    }

    public void OnAnimationEnd()
    {
        Animator gunAnimator = gun.GetComponent<Animator>();
        gunAnimator.SetBool("IsShooting", false);
    }

    void OnMiddleClick()
    {
        Debug.Log("interracted");
        trigger++;
        if (trigger == 1)
        {
            if (firstPerson)
            {
                LookCamera.enabled = false;
                ThirdPersonCamera.enabled = true;
                firstPerson = false;
            }
            else if (!firstPerson)
            {
                LookCamera.enabled = true;
                ThirdPersonCamera.enabled = false;
                firstPerson = true;
            }
        }
        else
            trigger = 0;
    }
}
