using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : SingleSceneSingleton<ThirdPersonMovement>
{
    public CharacterController controller;
    [SerializeField] private Transform cam;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private float speed;
    [SerializeField] private float gravity; 
    [SerializeField] private float turnSmoothTime;

    private float turnSmoothVelocity;
    private Vector3 velocity;
    private bool isGrounded;

    public void Activate()
    {
        enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GetComponentInChildren<Camera>().enabled = true;
    }

    public void Deactivate(bool showCursor = true)
    {
        enabled = false;
        if (showCursor)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        GetComponentInChildren<Camera>().enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        float horizontal = 0;
        float vertical = 0;

        if (PlayerSwitch.playerInVehicle == true)
        {
             horizontal = Input.GetAxisRaw("Horizontal");
             vertical = Input.GetAxisRaw("Vertical");
        }


        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
