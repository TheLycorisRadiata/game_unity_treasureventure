using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Keys
    private static KeyCode keyMenu, keyScreenMode, keyHelpMode, keyValidate, 
        keyUp, keyDown, keyLeft, keyRight, keySideLeft, keySideRight, keyJump;

    // Movement
    private static Rigidbody rb;
    private static float directionalSpeed;
    private static float rotateSpeed;
    private static float jumpForce;
    private static bool isOnGround;

    // Items
    public static int nbrCoins = 0;

    void Awake()
    {
        // TODO - Replace with the new input system

        // "Use Physical Keys" enabled (QWERTY)
        keyMenu = KeyCode.Escape;
        keyScreenMode = KeyCode.F11;
        keyHelpMode = KeyCode.F1;
        keyValidate = KeyCode.Return;
        keyUp = KeyCode.W;
        keyDown = KeyCode.S;
        keyLeft = KeyCode.A;
        keyRight = KeyCode.D;
        keySideLeft = KeyCode.Q;
        keySideRight = KeyCode.E;
        keyJump = KeyCode.Space;

        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        directionalSpeed = 5f;
        rotateSpeed = directionalSpeed * 12;
        jumpForce = 6f;
        isOnGround = false;
    }

    void Update()
    {
        // Move the player forward or backward
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(keyUp))
            transform.Translate(Vector3.forward * Time.deltaTime * directionalSpeed);
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(keyDown))
            transform.Translate(Vector3.back * Time.deltaTime * directionalSpeed);

        // Rotate the player to the left or the right
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(keyLeft))
            transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed);
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(keyRight))
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);

        // Move the player to the side
        if (Input.GetKey(keySideLeft))
            transform.Translate(Vector3.left * Time.deltaTime * directionalSpeed);
        if (Input.GetKey(keySideRight))
            transform.Translate(Vector3.right * Time.deltaTime * directionalSpeed);

        // Make the player jump
        if (Input.GetKeyDown(keyJump) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        // Switch between fullscreen and windowed mode
        if (Input.GetKeyDown(keyScreenMode))
            Screen.fullScreen = !Screen.fullScreen;

        // Toggle/Untoggle help mode
        if (Input.GetKeyDown(keyHelpMode))
        {
            // TODO - Help Mode
            Debug.Log("Help Key");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
