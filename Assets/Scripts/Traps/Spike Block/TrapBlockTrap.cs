using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBlockTrap : MonoBehaviour
{
    private static Rigidbody rb;
    private static PlayerHealthManager playerHealthManager;
    private static bool doesDamage;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerHealthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthManager>();
    }

    void Start()
    {
        doesDamage = true;
    }

    void OnTriggerEnter(Collider other)
    {
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
