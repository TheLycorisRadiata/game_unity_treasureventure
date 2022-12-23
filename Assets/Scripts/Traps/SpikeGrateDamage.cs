using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGrateDamage : MonoBehaviour
{
    PlayerHealthManager playerHealthManager;

    void Awake()
    {
        playerHealthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            playerHealthManager.RemoveLifePoints(20);
    }
}
