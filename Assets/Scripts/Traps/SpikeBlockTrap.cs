using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBlockTrap : MonoBehaviour
{
    private static AudioManager am;
    private static PlayerHealthManager playerHealthManager;
    private bool isActivated, isColliding;
    private float targetPositionY;

    void Awake()
    {
        am = FindObjectOfType<AudioManager>();
        playerHealthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthManager>();
    }

    void Start()
    {
        isActivated = false;
        isColliding = false;
        targetPositionY = transform.position.y - 4f;
    }

    void FixedUpdate()
    {
        if (isActivated && !isColliding)
        {
            if (transform.position.y > targetPositionY)
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
            else
            {
                isActivated = false;
                isColliding = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isActivated)
        {
            am.Play("TrapTriggered");
            am.Play("SpikeTrapMovement");
            isActivated = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        isColliding = true;

        if (collision.gameObject.CompareTag("Player"))
            playerHealthManager.RemoveLifePoints(50);
    }

    void OnCollisionExit()
    {
        isColliding = false;
    }
}
