using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingDoorInteraction : MonoBehaviour
{
    private Transform transformDoor;
    private Vector3 vectorOpen, vectorClosed;
    [SerializeField]
    private bool isOpen;

    void Awake()
    {
        transformDoor = transform.Find("Door").transform;
        vectorOpen = new Vector3(transformDoor.rotation.x, transformDoor.rotation.y - 90f, transformDoor.rotation.z);
        vectorClosed = new Vector3(transformDoor.rotation.x, transformDoor.rotation.y + 90f, transformDoor.rotation.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            transformDoor.Rotate(vectorOpen, Space.Self);
            isOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isOpen)
        {
            transformDoor.Rotate(vectorClosed, Space.Self);
            isOpen = false;
        }
    }
}
