using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float gravity = -9.81f;
    public float crouchSpeed = 2f;
    public float sprintSpeed = 8f;
    public float sprintDuration = 5f;
    public float sprintRechargeDelay = 2f;
    public float sprintRechargeSpeed = 2f;

    private bool isGrounded = true;
    private bool isCrouching = false;
    private bool isSprinting = false;
    private float sprintTimeLeft;
    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        sprintTimeLeft = sprintDuration;
    }

    void Update()
    {
        // Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        move.Normalize();

        if (isSprinting)
        {
            move *= sprintSpeed;
            sprintTimeLeft -= Time.deltaTime;
            if (sprintTimeLeft <= 0f)
            {
                isSprinting = false;
                sprintTimeLeft = 0f;
                Invoke("RechargeSprint", sprintRechargeDelay);
            }
        }
        else
        {
            move *= moveSpeed;
        }

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            isGrounded = false;
        }

        // Crouch
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = !isCrouching;
            if (isCrouching)
            {
                controller.height /= 2f;
                moveSpeed /= crouchSpeed;
            }
            else
            {
                controller.height *= 2f;
                moveSpeed *= crouchSpeed;
            }
        }

        // Sprint
        if (Input.GetKey(KeyCode.LeftShift) && !isCrouching && !isSprinting && sprintTimeLeft == sprintDuration)
        {
            isSprinting = true;
        }

        // Gravity
        if (controller.isGrounded)
        {
            velocity.y = 0f;
            isGrounded = true;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        // Apply movement
        controller.Move(move * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }

    void RechargeSprint()
    {
        float amountToRecharge = sprintRechargeSpeed * Time.deltaTime;
        sprintTimeLeft = Mathf.Min(sprintTimeLeft + amountToRecharge, sprintDuration);
    }
}