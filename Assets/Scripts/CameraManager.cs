using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    private static float distance, height;
    private static float sensitivity;
    private Transform target;
    private Vector3 back;

    void Awake()
    {
        // The camera is the target's child as to inherit its position
        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.SetParent(target);
    }

    void Start()
    {
        distance = 2f;
        height = 2.8f;
        sensitivity = .1f;
    }

    void LateUpdate()
    {
        back = -target.forward * distance;
        back.y = height;
        transform.position = target.position + back;
    }

    public void ControllableCameraRotation(InputValue axisValue)
    {
        Vector2 movementVector = axisValue.Get<Vector2>();
        float horizontalInput = movementVector.x * sensitivity;
        float verticalInput = Mathf.Clamp(-movementVector.y * sensitivity, -90f, 90f);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x + verticalInput, transform.eulerAngles.y + horizontalInput, transform.eulerAngles.z);
    }
}
