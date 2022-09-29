using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] private ActivePlayer playerTurn;
    [SerializeField] private TurnManager manager;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float airSpeed;
   // [SerializeField] private float airFriction;
    [SerializeField] Rigidbody rigidBody;


    // Camera values
    [SerializeField] private Camera characterCamera;
    [SerializeField] private float speedH = 2.0f;
    [SerializeField] private float speedV = 2.0f;
    [SerializeField] private float pitchClamp = 90;

    private Vector3 moveDirection;
    private Vector3 velocity;
    private Vector3 jumpVelocity = Vector3.zero;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] public LayerMask groundMask;
    [SerializeField] private float gravity;
    

    [SerializeField] private float jumpHeight;

    private CharacterController controller;

    BallStart shotBall;

    private void Start()
    {
        controller = GetComponent<CharacterController>();      
    }

    private void Update()
    {
       // ActivePlayer currentPlayer = manager.GetCurrentPlayer();
        Move();
        Camera();

        if (shotBall)
        {
            
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            
        }

    }


    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(moveX, 0, moveZ);

        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                //Walking
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Jump();  
            }
        }

        moveDirection *= moveSpeed;

        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Idle()
    {

    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
    }

    private void Run()
    {
        moveSpeed = runSpeed;
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
       // rigidBody.AddForce(Vector3.up * 500f);
    }
    public void Camera()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(transform.right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), Space.World);
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(transform.forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical"), Space.World);
        }

        ReadRotationInput();
    }

    private void ReadRotationInput()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -pitchClamp, pitchClamp);

        characterCamera.transform.localEulerAngles = new Vector3(pitch, 0.0f, 0.0f);
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }
}
