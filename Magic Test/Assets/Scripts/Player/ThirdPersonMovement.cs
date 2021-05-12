using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 20f;
    

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    private Vector3 lastMove;

    public float dashDistance = 5f;

    public Transform followTarget;

    float velocityY = 0;
    public float cameraSpeed = 200f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    /*void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(x, 0f, z).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            lastMove = moveDir;

        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }*/
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        velocityY += gravity * Time.deltaTime;
 
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        input = input.normalized;
 
        Vector3 temp = Vector3.zero;
        if (input.z > 0)
        {
            temp += followTarget.forward;
        }
        else if (input.z < 0)
        {
            temp += followTarget.forward * -1;
        }
 
        if (input.x > 0)
        {
            temp += followTarget.right;
        }
        else if (input.x < 0)
        {
            temp += followTarget.right * -1;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
 
        Vector3 velocity = temp * speed;
        velocity.y = velocityY;
     
        controller.Move(velocity * Time.deltaTime);

        lastMove = velocity;
 
        if (controller.isGrounded)
        {
            velocityY = 0;
        }

        followTarget.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0) * Time.deltaTime * cameraSpeed);
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * cameraSpeed);
    }

    public void HandleDash()
    {
        controller.Move(lastMove * speed * dashDistance * Time.deltaTime);
    }

}
