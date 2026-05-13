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
        //Locks cursur to game window
        Cursor.lockState = CursorLockMode.Locked;
        head = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //make camera rotate with mouse movement
        xRotation += -LookInput.y * Sensitivity.y;
        head.transform.localEulerAngles = new(xRotation, 0, 0);
        transform.Rotate(Vector3.up, LookInput.x * Sensitivity.x);
        //Makes it so you cannot flip the Camera upside down
        xRotation = Mathf.Clamp(xRotation, -90, 90);
    }

    void OnLook(InputValue value)
    {
        //Gets mouse movement
        LookInput = value.Get<Vector2>();
    }

    void OnClick()
    {
        //gets gun animator
        Animator gunAnimator = gun.GetComponent<Animator>();
        //Shoots out raycast to detect if you hit a enemy
        RaycastHit hit;
        //Detects if shooting is on cooldown depending on if animation is still playing
        if (gunAnimator.GetBool("IsShooting") != true)
        {
            //Gets the first or third person camera
            Camera shootCamera;
            gunAnimator.SetBool("IsShooting", true);
            if (firstPerson)
                shootCamera = LookCamera;
            else
                shootCamera = ThirdPersonCamera;
            //Detects if raycast hit enemy
            if (
                Physics.Raycast(
                    shootCamera.transform.position,
                    shootCamera.transform.forward,
                    out hit
                )
            )
            {
                //Kills hit enemy
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

    //Detects when shooting animation ended
    public void OnAnimationEnd()
    {
        Animator gunAnimator = gun.GetComponent<Animator>();
        gunAnimator.SetBool("IsShooting", false);
    }

    //Switch to third person
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
