using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField] private float walkSpeed = 2.0f;
    [SerializeField] private float runSpeed = 5.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float heightJumpHeigh = 2.0f;
    [SerializeField] private float gravity = -9.81f;
    [Header("Looking")]
    [SerializeField] private Transform vc_player;
    [SerializeField] private float lookSpeed = 2.0f;
    [SerializeField] private float lookXLimit = 80.0f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool groundedPlayer;
    private bool run;

    private float rotationX;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.CanMove)
            return;


        groundedPlayer = controller.isGrounded;
        run = Input.GetButton("Run");

        //Movement
        if(groundedPlayer && velocity.y <= 0)
        {
            velocity.y = 0f;
        }

        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        Vector3 move = Input.GetAxis("Horizontal")* right +  Input.GetAxis("Vertical")*forward;
        move.y = 0;

        controller.Move(move.normalized * Time.deltaTime * ( run ? runSpeed : walkSpeed ));

        if(Input.GetButtonDown("Jump") &&  groundedPlayer) 
        {
            velocity.y = Mathf.Sqrt(-3.0f * gravity * (PlayerManager.HeighJump ? heightJumpHeigh : jumpHeight) );
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);




        //Rotation

        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        vc_player.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);


    }
}
