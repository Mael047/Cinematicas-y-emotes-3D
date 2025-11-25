using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float horizontalMove;
    public float verticalMove;
    private Vector3 playerInput;

    public CharacterController player;

    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    private float currentSpeed;


    private Vector3 movePlayer;
    public float gravity = 9.8f;
    public float fallVelocity;

    public Camera playerCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    //Variables de animacion 
    public Animator playerAnimatorController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<CharacterController>();
        playerAnimatorController = GetComponent<Animator>();

        currentSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        bool isRuning = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = isRuning ? runSpeed : walkSpeed;

        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, 5 * Time.deltaTime);

        playerAnimatorController.SetFloat("PlayerWalkVelocity", playerInput.magnitude * currentSpeed);

        camDirection();

        movePlayer = playerInput.z * camForward + playerInput.x * camRight;

        movePlayer = movePlayer * currentSpeed;

        player.transform.LookAt(player.transform.position + movePlayer);

        SetGravity();

        player.Move(movePlayer * Time.deltaTime);


        //emotes

        animaciones();


    }

    void camDirection()
    {
        camForward = playerCamera.transform.forward;
        camRight = playerCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    void SetGravity()
    {
        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
    }

    private void OnAnimatorMove()
    {
        
    }

    private void desactivarAnimaciones()
    {
        playerAnimatorController.SetBool("dance",false);
        playerAnimatorController.SetBool("sit",false);
        playerAnimatorController.SetBool("reverencia",false);
        
    }

    private void animaciones()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            desactivarAnimaciones();
            playerAnimatorController.SetBool("dance",true);
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            desactivarAnimaciones();
            playerAnimatorController.SetBool("sit",true);
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            desactivarAnimaciones();
            playerAnimatorController.SetBool("reverencia",true);
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            desactivarAnimaciones();
            playerAnimatorController.SetBool("pick",true);
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
            desactivarAnimaciones();
            playerAnimatorController.SetBool("sentarse",true);
        }
        if(Input.GetMouseButtonDown(0))
        {
            desactivarAnimaciones();
            playerAnimatorController.SetTrigger("attack");
        }
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)  )
        {
            playerAnimatorController.SetBool("dance",false);
            playerAnimatorController.SetBool("sit",false);
            playerAnimatorController.SetBool("reverencia",false);
            playerAnimatorController.SetBool("pick",false);
            playerAnimatorController.SetBool("sentarse",false);
        }
    }

}
