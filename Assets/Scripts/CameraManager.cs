using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private static Transform target;
    private static Vector3 back;
    private static float distance, height;

    void Awake()
    {
        // The camera is the target's child as to inherit its position
        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.SetParent(target);
    }

    void Start()
    {
        distance = 1.5f;
        height = 1.5f;
    }

    void LateUpdate()
    {
        back = -target.forward * distance;
        back.y = height;
        transform.position = target.position + back;
    }
}
