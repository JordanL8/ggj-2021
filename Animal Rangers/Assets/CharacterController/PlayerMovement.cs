using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : SingleSceneSingleton<PlayerMovement>
{
    public CharacterController controller;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private float speed;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;

    private Vector3 velocity;
    private bool isGrounded;

    protected override void Awake()
    {
        base.Awake();
        Activate();
    }

    public void Activate()
    {
        enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        MinimapManager.Instance.SetTarget(transform);
        GetComponentInChildren<MouseLook>().enabled = true;
        controller.GetComponent<CharacterController>().enabled = true;
        if (PlayerSwitch.playerInVehicle)
        {
            controller.transform.position = ThirdPersonMovement.Instance.controller.transform.position;
        }
    }

    public void Deactivate(bool showCursor = true)
    {
        enabled = false;
        if (showCursor)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        GetComponentInChildren<MouseLook>().enabled = false;
        controller.GetComponent<CharacterController>().enabled = false;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
