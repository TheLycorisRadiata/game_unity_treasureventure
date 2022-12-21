using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBlockTrap : MonoBehaviour
{
    private static AudioManager am;
    private static Rigidbody rb;
    private static PlayerHealthManager playerHealthManager;
    private static bool doesDamage;

    void Awake()
    {
        am = FindObjectOfType<AudioManager>();
        rb = GetComponent<Rigidbody>();
        playerHealthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthManager>();
    }

    void Start()
    {
        doesDamage = true;
    }

    void OnTriggerEnter(Collider other)
    {
        am.Play("TrapTriggered");
        am.Play("SpikeTrapMovement");
        rb.isKinematic = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (doesDamage && collision.gameObject.CompareTag("Player"))
        {
            playerHealthManager.RemoveLifePoints(50);
            doesDamage = false;
        }
    }
}
