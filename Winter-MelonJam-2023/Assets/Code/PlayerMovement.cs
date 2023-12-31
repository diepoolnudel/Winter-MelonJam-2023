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
    [SerializeField] public static float lookSpeed = 1.5f;
    [SerializeField] private float lookXLimit = 80.0f;
    [Header("Sound")]
    [SerializeField] private float walkCooldown = 0.8f;
    [SerializeField] private float runCooldown = 0.4f;
    [SerializeField] private AudioSource as_steps;
    [SerializeField] private AudioSource as_jump;
    [SerializeField] private AudioClip[] stepSounds;
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip jumpwithCharme;
    private float timer;

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

        //sound
        timer += Time.deltaTime;
        if (move.sqrMagnitude >= 0.05 && groundedPlayer)
        {
            PlaySteps();
            
        }


        //Movemetn
        controller.Move(move.normalized * Time.deltaTime * ( run ? runSpeed : walkSpeed ));

        // Jump
        if(Input.GetButtonDown("Jump") &&  groundedPlayer) 
        {
            velocity.y = Mathf.Sqrt(-3.0f * gravity * (PlayerManager.HeighJump ? heightJumpHeigh : jumpHeight) );
            as_jump.PlayOneShot((PlayerManager.HeighJump ? jumpwithCharme : jump));

        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);




        //Rotation

        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed/10;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        vc_player.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed/10, 0);


    }





    private void PlaySteps()
    {

       

        if (timer >= (run ? runCooldown : walkCooldown))
        {
            int i = Random.Range(0, stepSounds.Length);
            Debug.Log(i);
            timer = 0;
            as_steps.PlayOneShot(stepSounds[i]);

        }

    }
}
