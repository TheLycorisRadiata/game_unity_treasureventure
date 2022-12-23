using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBlockTrap : MonoBehaviour
{
    private static AudioManager am;
    private static PlayerHealthManager playerHealthManager;
    private Rigidbody rb;
    private bool isActivated;

    void Awake()
    {
        am = FindObjectOfType<AudioManager>();
        playerHealthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthManager>();
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isActivated)
        {
            am.Play("TrapTriggered");
            am.Play("SpikeTrapMovement");
            rb.isKinematic = false;
            isActivated = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            playerHealthManager.RemoveLifePoints(50);
    }
}
