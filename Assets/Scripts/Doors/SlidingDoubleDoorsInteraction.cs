using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoubleDoorsInteraction : MonoBehaviour
{
    private static AudioManager am;
    private static Sound[] arrSounds;
    private static float valueOpen, valueClosed;
    private Transform transformLeftDoor, transformRightDoor;
    private bool isLeftOpen, isRightOpen;
    private Vector3 leftOpenVector, rightOpenVector, leftClosedVector, rightClosedVector;

    void Awake()
    {
        am = FindObjectOfType<AudioManager>();
        arrSounds = new Sound[2];
        arrSounds[0] = am.AddAudioSource("SlidingDoorOpening", gameObject);
        arrSounds[1] = am.AddAudioSource("SlidingDoorClosing", gameObject);

        valueOpen = 2.6f;
        valueClosed = 1.1f;

        transformLeftDoor = transform.Find("Left Door").transform;
        isLeftOpen = transformLeftDoor.localPosition.x != -valueClosed;
        leftOpenVector = new Vector3(-valueOpen, transformLeftDoor.localPosition.y, transformLeftDoor.localPosition.z);
        leftClosedVector = new Vector3(-valueClosed, transformLeftDoor.localPosition.y, transformLeftDoor.localPosition.z);

        transformRightDoor = transform.Find("Right Door").transform;
        isRightOpen = transformRightDoor.localPosition.x != valueClosed;
        rightOpenVector = new Vector3(valueOpen, transformRightDoor.localPosition.y, transformRightDoor.localPosition.z);
        rightClosedVector = new Vector3(valueClosed, transformRightDoor.localPosition.y, transformRightDoor.localPosition.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (!isLeftOpen || !isRightOpen))
        {
            am.Play(Array.Find(arrSounds, item => item.name == "SlidingDoorOpening"), "SlidingDoorOpening");
            transformLeftDoor.localPosition = leftOpenVector;
            transformRightDoor.localPosition = rightOpenVector;
            isLeftOpen = true;
            isRightOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && (isLeftOpen || isRightOpen))
        {
            am.Play(Array.Find(arrSounds, item => item.name == "SlidingDoorOpening"), "SlidingDoorClosing");
            transformLeftDoor.localPosition = leftClosedVector;
            transformRightDoor.localPosition = rightClosedVector;
            isLeftOpen = false;
            isRightOpen = false;
        }
    }
}
