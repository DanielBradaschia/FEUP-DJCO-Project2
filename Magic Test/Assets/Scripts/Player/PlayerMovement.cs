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

    public float gravity = -36f;
    public float jumpHeight = 3f;
    private Vector3 lastMove;

    public float dashDistance = 100f;

    public Transform followTarget;

    float velocityY = 0;
    public float cameraSpeed = 5f;

    [SerializeField]
    Animator animator;
    float movingForward;
    float movingSideways;

    GameObject stepSound;
    GameObject jumpSound;
    bool stepSoundBool = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        followTarget.localEulerAngles = new Vector3(0, 0, 0);
        stepSound = transform.Find("StepSound").gameObject;
        jumpSound = transform.Find("JumpSound").gameObject;
    }

    
    void Update()
    {
        //
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        

        velocityY += gravity * Time.deltaTime;

        movingForward = Input.GetAxisRaw("Vertical");
        movingSideways = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Forward", movingForward);
        animator.SetFloat("Sideways", movingSideways);

        Vector3 input = new Vector3(movingSideways, 0, movingForward);
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
            jumpSound.SetActive(true);
            animator.SetBool("Jump", true);
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
 
        Vector3 velocity = temp * speed;
        velocity.y = velocityY;
     
        controller.Move(velocity * Time.deltaTime);

        lastMove = velocity;

        if(velocity.z != 0) {
            if(controller.isGrounded)
            {
                if(!stepSoundBool)
                {
                    stepSound.SetActive(true);
                    Invoke(nameof(StopStep), 0.35f);
                    stepSoundBool = true;
                }
            }
            Quaternion rotation = followTarget.rotation;
            rotation.x = 0;
            rotation. z = 0;
            transform.rotation = rotation;
            followTarget.localEulerAngles = new Vector3(followTarget.localEulerAngles.x, 0, 0);
        } else {
            StopStep();
        }
 
        if (controller.isGrounded)
        {
            jumpSound.SetActive(false);
            animator.SetBool("Jump", false);
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
        controller.Move(lastMove * dashDistance * Time.deltaTime);
    }

    public void HandleDoubleJump()
    {
        velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    private void StopStep()
    {
        stepSound.SetActive(false);
        stepSoundBool = false;
    }

}
