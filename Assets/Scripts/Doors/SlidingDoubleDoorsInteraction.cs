using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoubleDoorsInteraction : MonoBehaviour
{
    private static float valueOpen, valueClosed;
    private Transform transformLeftDoor, transformRightDoor;
    private bool isLeftOpen, isRightOpen;

    void Awake()
    {
        valueOpen = 2.6f;
        valueClosed = 1.1f;
        transformLeftDoor = transform.Find("Left Door").transform;
        transformRightDoor = transform.Find("Right Door").transform;
        isLeftOpen = transformLeftDoor.localPosition.x != -valueClosed;
        isRightOpen = transformRightDoor.localPosition.x != valueClosed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (!isLeftOpen || !isRightOpen))
        {
            transformLeftDoor.localPosition = new Vector3(-valueOpen, transformLeftDoor.localPosition.y, transformLeftDoor.localPosition.z);
            transformRightDoor.localPosition = new Vector3(valueOpen, transformLeftDoor.localPosition.y, transformLeftDoor.localPosition.z);
            isLeftOpen = true;
            isRightOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && (isLeftOpen || isRightOpen))
        {
            transformLeftDoor.localPosition = new Vector3(-valueClosed, transformLeftDoor.localPosition.y, transformLeftDoor.localPosition.z);
            transformRightDoor.localPosition = new Vector3(valueClosed, transformLeftDoor.localPosition.y, transformLeftDoor.localPosition.z);
            isLeftOpen = false;
            isRightOpen = false;
        }
    }
}
