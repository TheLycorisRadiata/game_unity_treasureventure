using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingDoorInteraction : MonoBehaviour
{
    private static AudioManager am;
    private Transform transformDoor;
    private Vector3 vectorOpen, vectorClosed;
    private bool isOpen;
    [SerializeField]
    private bool isMetalDoor;

    void Awake()
    {
        am = FindObjectOfType<AudioManager>();
        transformDoor = transform.Find("Door").transform;
        isOpen = transformDoor.localRotation.y != 0;
        vectorOpen = new Vector3(transformDoor.rotation.x, transformDoor.rotation.y - 90f, transformDoor.rotation.z);
        vectorClosed = new Vector3(transformDoor.rotation.x, transformDoor.rotation.y + 90f, transformDoor.rotation.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            if (isMetalDoor)
                am.Play("MetalDoorOpening");
            else
                am.Play("RotatingDoorOpening");
            transformDoor.Rotate(vectorOpen, Space.Self);
            isOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isOpen)
        {
            if (isMetalDoor)
                am.Play("MetalDoorClosing");
            else
                am.Play("RotatingDoorClosing");
            transformDoor.Rotate(vectorClosed, Space.Self);
            isOpen = false;
        }
    }
}
