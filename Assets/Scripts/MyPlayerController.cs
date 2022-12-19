//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem;

//[RequireComponent(typeof(CharacterController))]
//[RequireComponent(typeof(Rigidbody2D))]

//public class MyPlayerController : MonoBehaviour
//{
//[SerializeField] InputActionAsset playerControls;
//InputAction movement;

//public InputAction move;

//private Rigidbody2D rb;

//CharacterController character;
//Vector3 moveVector;
//[SerializeField] float speed = 5.0f;


//private void Start()
//{
//    rb = GetComponent<Rigidbody>();
//    var gameplayActionMap = playerControls.FindActionMap("MyPlayerControls");
//    movement = gameplayActionMap.FindAction("MyMovementsInputs");
//    movement.performed += OnMovementsChanged;
//    movement.canceled += OnMovementsChanged;
//    movement.Enable();

//    character= GetComponent<CharacterController>();
//}

//private void FixedUpdate()
//{
//    character.Move(moveVector * speed * Time.fixedDeltaTime);
//}

//private void Awake()
//{
//    rb = GetComponent<Rigidbody2D>();
//    // rb.GetComponent<Rigidbody2D>().velocity = moveVector;
//}
//public void OnMovementsChanged(InputAction.CallbackContext context)
//{
//    rb.velocity = context.ReadValue<Vector2>() * speed;
//    Vector2 direction = context.ReadValue<Vector2>();
//    moveVector = new Vector3(direction.x,0,direction.y);

//}

//public void OnMovementsChanged(InputAction.CallbackContext context)
//{
//    Vector2 direction = context.ReadValue<Vector2>();
//    moveVector = new Vector3(direction.x,0,direction.y);

//    }
//}
// To see later (from Unity tutos NOK)
//{
//    MYNewInputControls controls;
//    Vector2 move;
//    [SerializeField] float speed = 5.0f;

//    void Awake()
//    {
//        controls = new MYNewInputControls();
//        controls.MyPlayerControls.MyMovementsInputs.performed += ctx => SendMessage(ctx.ReadValue<Vector2>());
//        controls.MyPlayerControls.MyMovementsInputs.performed += ctx => move = ctx.ReadValue<Vector2>();
//        controls.MyPlayerControls.MyMovementsInputs.canceled += ctx => move = Vector2.zero;
//    }

//    private void OnEnable()
//    {
//        controls.MyPlayerControls.Enable();
//    }
//    private void OnDisable()
//    {
//        controls.MyPlayerControls.Disable();
//    }

//    void SendMessage(Vector2 coordinates)
//    {
//        Debug.Log("Thumb-stick coordinates = " + coordinates);
//    }

//    void FixedUpdate()
//    {
//        Vector3 movement = new Vector3(move.x, 0.0f, move.y) * speed * Time.deltaTime;
//        transform.Translate(movement, Space.World);
//    }
//}





//    The older working MyPlayerController Script

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


public class MyPlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public GameObject camHolder;
    public float speed, sensitivity, maxForce;

    private PlayerInput PlayerInput;
    private Vector2 move, look;
    private float lookRotation;

    public void OnMyMovementsInputs(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // Find target velocity.
        Vector3 currentVelocity = playerRigidbody.velocity;
        Vector3 targetVelocity = new Vector3(move.x,0,move.y);
        targetVelocity *= speed;

        // Align direction.
        targetVelocity = transform.TransformDirection(targetVelocity);

        // Calculate force to apply.
        Vector3 velocityChange = (targetVelocity - currentVelocity);

        // Limit force to apply.
        Vector3.ClampMagnitude(velocityChange, maxForce);

        playerRigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    private void LateUpdate()
    {
        // Turn.
        transform.Rotate(Vector3.up * look.x * sensitivity);

        // look up and down.
        lookRotation += (-look.y * sensitivity);
        camHolder.transform.eulerAngles = new Vector3(lookRotation, camHolder.transform.eulerAngles.y, camHolder.transform.eulerAngles.z);
    }







    //private float movementX;
    //private float movementY;

    //private void Awake()
    //{
    //    playerRigidbody = GetComponent<Rigidbody>();
    //    PlayerInput= GetComponent<PlayerInput>();
    //    PlayerInput.onActionTriggered += PlayerInput_onActionTriggered;
    //}

    //private void PlayerInput_onActionTriggered(InputAction.CallbackContext context)
    //{
    //    throw new System.NotImplementedException();
    //}

    //public void Jump(InputAction.CallbackContext context)
    //{
    //    Debug.Log(context);
    //   playerRigidbody.AddForce(Vector3.down * speed, ForceMode.Impulse);
    //}
    // The private void "OnMyMovementsInputs()" is the "On" + "name of actions defined in the assets Actions configuration panel.
    //private void OnMyMovementsInputs(InputValue movementValue)
    //{
    //    Vector2 movementVector = movementValue.Get<Vector2>();

    //    movementX = movementVector.x;
    //    movementY = movementVector.y;

    //    Debug.Log("MyMovementsInputs");
    //    Debug.Log("JumpInput");
    //}

    //void FixedUpdate()
    //{
    //    Vector3 movement = new Vector3(movementX, 0.0f, movementY);
    //    rb.AddForce(movement * speed);
    //}
}
