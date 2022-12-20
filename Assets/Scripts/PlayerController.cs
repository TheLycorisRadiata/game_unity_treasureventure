using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Script references
    private static AudioManager am;

    // Movement
    private static Rigidbody rb;
    private static float horizontalInput, verticalInput, sideStepInput;
    private static float directionalSpeed;
    private static float rotateSpeed;
    private static float jumpForce;
    private static bool isOnGround;

    // Items
    public static int nbrCoins = 0;

    void Awake()
    {
        am = FindObjectOfType<AudioManager>();
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        directionalSpeed = 5f;
        rotateSpeed = directionalSpeed * 12;
        jumpForce = 6f;
        isOnGround = false;

        am.Play("Theme");
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(sideStepInput, 0f, verticalInput);
        Vector3 rotation = new Vector3(0f, horizontalInput, 0f);

        transform.Translate(movement * Time.deltaTime * directionalSpeed);
        transform.Rotate(rotation * Time.deltaTime * rotateSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }

    void OnMove(InputValue axisValue)
    {
        Vector2 movementVector = axisValue.Get<Vector2>();
        horizontalInput = movementVector.x;
        verticalInput = movementVector.y;
    }

    void OnSideStep(InputValue sideStepValue)
    {
        sideStepInput = sideStepValue.Get<float>();
    }

    void OnJump()
    {
        if (isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    void OnScreenMode()
    {
        // Switch between fullscreen and windowed mode
        Screen.fullScreen = !Screen.fullScreen;
    }

    void OnHelpMode()
    {
        // Toggle/Untoggle help mode
        // TODO - Help Mode
        Debug.Log("Help Key");
    }
}
