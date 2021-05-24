using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
    public float cameraSpeed = 5f;

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

        if(velocity.z != 0) {
            Quaternion rotation = followTarget.rotation;
            rotation.x = 0;
            rotation. z = 0;
            transform.rotation = rotation;
            followTarget.localEulerAngles = new Vector3(followTarget.localEulerAngles.x, 0, 0);
        }
 
        if (controller.isGrounded)
        {
            velocityY = 0;
        }

        float newX = -Input.GetAxis("Mouse Y");
        float newY = Input.GetAxis("Mouse X");
        if((followTarget.localEulerAngles.x > 300 && followTarget.localEulerAngles.x < 340 && newX < 0) || (followTarget.localEulerAngles.x > 70 && followTarget.localEulerAngles.x < 300 && newX > 0))
        {
            newX = 0;
        }
        followTarget.localEulerAngles += new Vector3(newX, newY, 0) * cameraSpeed;
        
    }

    public void HandleDash()
    {
        controller.Move(lastMove * speed * dashDistance * Time.deltaTime);
    }

}
