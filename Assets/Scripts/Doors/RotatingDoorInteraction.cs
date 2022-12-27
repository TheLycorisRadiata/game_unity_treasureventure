using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingDoorInteraction : MonoBehaviour
{
    private static AudioManager am;
    private static Sound[] arrSounds;
    private Transform transformDoor;
    private Vector3 vectorOpen, vectorClosed;
    private bool isOpen;
    [SerializeField]
    private bool isMetalDoor;

    void Awake()
    {
        am = FindObjectOfType<AudioManager>();
        arrSounds = new Sound[4];
        arrSounds[0] = am.AddAudioSource("MetalDoorOpening", gameObject);
        arrSounds[1] = am.AddAudioSource("MetalDoorClosing", gameObject);
        arrSounds[2] = am.AddAudioSource("RotatingDoorOpening", gameObject);
        arrSounds[3] = am.AddAudioSource("RotatingDoorClosing", gameObject);

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
                am.Play(Array.Find(arrSounds, item => item.name == "MetalDoorOpening"), "MetalDoorOpening");
            else
                am.Play(Array.Find(arrSounds, item => item.name == "RotatingDoorOpening"), "RotatingDoorOpening");
            transformDoor.Rotate(vectorOpen, Space.Self);
            isOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isOpen)
        {
            if (isMetalDoor)
                am.Play(Array.Find(arrSounds, item => item.name == "MetalDoorClosing"), "MetalDoorClosing");
            else
                am.Play(Array.Find(arrSounds, item => item.name == "RotatingDoorClosing"), "RotatingDoorClosing");
            transformDoor.Rotate(vectorClosed, Space.Self);
            isOpen = false;
        }
    }
}
